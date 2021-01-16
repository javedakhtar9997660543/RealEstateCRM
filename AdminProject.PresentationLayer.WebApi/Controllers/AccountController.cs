using System.Threading.Tasks;
using AdminProject.PresentationLayer.WebApi.Helpers;
using AdminProject.PresentationLayer.WebApi.Model;
using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.CommonLayer.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AdminProject.PresentationLayer.WebApi.Controllers
{
    [Route("api")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly ISecurityService _securityBusinessInstance;
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly IUserService _userBusinessInstance;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userBusinessInstance,
            ITokenClaimsService tokenClaimsService,
            IConfiguration config,
            IEmailService emailService,
            ISecurityService securityBusinessInstance, ILogger<AccountController> logger)
        {
            _tokenClaimsService = tokenClaimsService;
            _userBusinessInstance = userBusinessInstance;
            _config = config;
            _emailService = emailService;
            _securityBusinessInstance = securityBusinessInstance;
            _logger = logger;
            _logger.LogDebug(1, "Logger injected into AccountsController");
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Authenticate user details.");
            var response = new AuthenticateResponse(request.CorrelationId());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userBusinessInstance.AuthenticateUser(request.Username, request.Password);
            if (result == null) return Unauthorized();
            response.IsSuccess = true;
            response.ExpiresIn = int.Parse(_config.GetSection("Tokens").GetSection("Lifetime").Value);

            response.Token = await _tokenClaimsService.GetToken(result.Id);
            return response;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterUser([FromBody] UserMasterDto user)
        {
            if (user == null) return BadRequest();
            var userExists = await _userBusinessInstance.IsUserAlreadyExists(user.Email);
            if (userExists) throw new AppException("User with email address: " + user.Email + " already registered with us. Please follow the email we sent now.");

            var id = await _userBusinessInstance.AddNewUserAsync(user);
            return Ok(new { SingleResult = id, IsSuccess = true });

        }

        [HttpPost("forget-password")]
        public async Task<ActionResult<JsonResponse<UserMasterDto>>> ForgetPasswordNotification([FromBody] LoginModel model)
        {
            var response = new JsonResponse<UserMasterDto>();
            if (string.IsNullOrEmpty(model.Email))
                return BadRequest();

            var user = await _userBusinessInstance.GetUserByEmailAsync(model.Email);
            if (user == null) throw new AppException("Email address incorrect. No user found.");

            var uniqueString = await _securityBusinessInstance.GetOtpAsync(user.Id);
            if (string.IsNullOrEmpty(uniqueString)) throw new AppException("User not found.");


            await _emailService.PrepareAndSendEmailAsync(user, uniqueString, AspectEnums.TemplateType.ResetPassword, null);
            response.IsSuccess = true;
            response.SingleResult = user;
            response.Message = "Please check your registered email for reset password link.";

            return Ok(response);
        }

        [HttpGet]
        [Route("validate-reset-url/{id}")]
        public async Task<ActionResult<JsonResponse<UserMasterDto>>> ValidatePasswordResetUrl(string id)
        {
            var response = new JsonResponse<UserMasterDto>();

            var isValid = await _securityBusinessInstance.ValidateGuidAsync(id);
            if (!isValid)
                throw new AppException("Password reset link is expired or invalid. Try again later.");
            response.SingleResult = await _userBusinessInstance.GetUserByGuidAsync(id);
            response.IsSuccess = true;

            return Ok(response);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<JsonResponse<bool>> ResetPassword(ResetPasswordRequest model)
        {
            var response = new JsonResponse<bool>();
            var user = await _userBusinessInstance.GetUserByGuidAsync(model.Token);
            if (user == null)
                throw new AppException("Invalid user token.");

            response.SingleResult = await _userBusinessInstance.ChangePasswordAsync(model.Token, model.Password);
            response.IsSuccess = response.SingleResult;
            response.StatusCode = 200;
            response.Message = "Your password has been successfully updated.";

            return response;
        }

    }
}