using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AdminProject.CommonLayer.Application.AppSettings;
using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Entities;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AdminProject.BusinessLayer.ServiceManager
{
    public class EmailServiceManager : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        private readonly SmtpSettings _smtpSettings;
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _env;

        private readonly string _company;
        private readonly string _baseUrl;

        public EmailServiceManager(IEmailRepository emailRepository,
            IMapper mapper,
            IOptions<SmtpSettings> smtpSettings,
            IWebHostEnvironment env,
            IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _emailRepository = emailRepository;
            _smtpSettings = smtpSettings.Value;
            _env = env;
            _appSettings = appSettings.Value;
            _company = _appSettings.Company;
            _baseUrl = _appSettings.HostUrl;
        }
        public Task<int> SubmitContactUs(ContactUsDTO model)
        {
            return _emailRepository.SubmitContactUs(_mapper.Map<ContactUsDTO, ContactUs>(model));
        }

        public async Task PrepareAndSendEmailAsync(UserMasterDto user, string otherText, AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code)
        {
            var template = await _emailRepository.GetEmailWithFieldsAsync(type, code);
            var email = PrepareEmailBody(user, otherText, template);
            await SendEmailAsync(email);
        }

        public async Task<EmailTemplateDto> GetEmailTemplateAsync(AspectEnums.TemplateType type, AspectEnums.EmailTemplateCode? code)
        {
            var template = await _emailRepository.GetEmailWithFieldsAsync(type, code);
            return _mapper.Map<EmailTemplate, EmailTemplateDto>(template);
        }

        private EmailsDto PrepareEmailBody(UserMasterDto user, string uniqueText, EmailTemplate template)
        {
            StringBuilder body = new StringBuilder(template.HtmlContent);
            StringBuilder subject = new StringBuilder(template.Subject);
            var fields = template.EmailMergeFields;
            foreach (var item in fields)
            {
                switch (item.SrcField)
                {
                    case "FNAME":
                        item.SrcFieldValue ??= user.FirstName;
                        body.Replace("{{FNAME}}", item.SrcFieldValue);
                        subject.Replace("{{FNAME}}", item.SrcFieldValue);
                        break;
                    case "LNAME":
                        item.SrcFieldValue ??= user.LastName;
                        body.Replace("{{LNAME}}", item.SrcFieldValue);
                        subject.Replace("{{LNAME}}", item.SrcFieldValue);
                        break;
                    case "EMAIL":
                        item.SrcFieldValue ??= user.Email;
                        body.Replace("{{EMAIL}}", item.SrcFieldValue);
                        subject.Replace("{{EMAIL}}", item.SrcFieldValue);
                        break;
                    case "UNIQUESTR":
                        item.SrcFieldValue ??= uniqueText;
                        body.Replace("{{UNIQUESTR}}", item.SrcFieldValue);
                        subject.Replace("{{UNIQUESTR}}", item.SrcFieldValue);
                        break;
                    case "URL":
                        item.SrcFieldValue ??= uniqueText;
                        body.Replace("{{URL}}", item.SrcFieldValue);
                        subject.Replace("{{URL}}", item.SrcFieldValue);
                        break;
                    case "COMPANY":
                        item.SrcFieldValue ??= uniqueText;
                        body.Replace("{{COMPANY}}", item.SrcFieldValue);
                        subject.Replace("{{COMPANY}}", item.SrcFieldValue);
                        break;
                    default:
                        body.Replace("{{FNAME}}", user.FirstName);
                        body.Replace("{{COMPANY}}", _company);
                        body.Replace("{{EMAIL}}", user.Email);
                        break;
                }
            }

            return new EmailsDto
            {
                FromEmail = _smtpSettings.SenderEmail,
                FromName = _smtpSettings.SenderName,
                ToEmail = user.Email,
                ToName = user.FirstName,
                Mobile = user?.Mobile,
                Message = body.ToString(),
                Body = body.ToString(),
                AttachmentFileName = "Attachment",
                Subject = subject.ToString()
            };
        }

        public async Task SendAlreadyRegisteredEmail(UserMasterDto user)
        {
            var template = new EmailTemplate();

            string message = $@"<p>If you don't know your password please visit the <a href=""{_baseUrl}/account/forgot-password"">forgot password</a> page.</p>";
            template.Subject = "Sign-up Verification API - Email Already Registered";
            template.HtmlContent = $@"<h4>Email Already Registered</h4>
                         <p>Your email <strong>{{EMAIL}}</strong> is already registered.</p>
                         {message}";
            var email = PrepareEmailBody(user, String.Empty, template);
            await SendEmailAsync(email);
        }

        public async Task SendEmailAsync(EmailsDto mailRequest)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_smtpSettings.SenderEmail)
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments.Where(file => file.Length > 0))
                {
                    byte[] fileBytes;
                    await using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };

            if (_env.IsDevelopment())
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
            }
            else
            {
                await client.ConnectAsync(_smtpSettings.Server);
            }

            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await client.SendAsync(email);
            await client.DisconnectAsync(true);
        }
    }
}
