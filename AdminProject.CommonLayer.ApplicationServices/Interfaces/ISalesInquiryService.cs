using AdminProject.CommonLayer.Application.DTO.CRM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminProject.CommonLayer.Application.Interfaces
{
    public interface ISalesInquiryService
    {
        Task<List<SalesInquiryDto>> GetSalesInquiries();
        Task<List<SalesInquiryDto>> GetSalesInquiriesByEmp(int userId);
        Task<List<SalesInquiryDto>> GetSalesInquiriesByCust(int customerId);
        Task<List<SalesInquiryDto>> GetSalesInquiriesByDateRange(DateTime startDate, DateTime endDate);
        Task<List<SalesInquiryDto>> GetSalesInquiriesByProperty(int propertyId);
        Task<SalesInquiryDto> GetSalesInquiry(int Id);
        Task<int> AddNewSalesInquiry(SalesInquiryDto inquiry);
        Task<bool> UpdateSalesInquiry(SalesInquiryDto inquiry);
        Task<bool> DeleteSalesInquiry(int Id);
    }
}
