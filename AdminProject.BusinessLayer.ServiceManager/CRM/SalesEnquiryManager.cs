using AdminProject.CommonLayer.Application.DTO.CRM;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.PersistenceLayer.Repository.PersistenceServices.CRM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminProject.BusinessLayer.ServiceManager.CRM
{
    public class SalesEnquiryManager : ISalesInquiryService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public SalesEnquiryManager(ISalesRepository salesRepository, IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _emailService = emailService;
            _salesRepository = salesRepository;
        }
        public Task<int> AddNewSalesInquiry(SalesInquiryDto inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSalesInquiry(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiryDto>> GetSalesInquiries()
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiryDto>> GetSalesInquiriesByCust(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiryDto>> GetSalesInquiriesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiryDto>> GetSalesInquiriesByEmp(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiryDto>> GetSalesInquiriesByProperty(int propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInquiryDto> GetSalesInquiry(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSalesInquiry(SalesInquiryDto inquiry)
        {
            throw new NotImplementedException();
        }
    }
}
