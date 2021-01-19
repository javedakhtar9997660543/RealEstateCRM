using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.PersistenceServices.CRM
{
    public interface ISalesRepository
    {
        Task<List<SalesInquiry>> GetSalesInquiries();
        Task<List<SalesInquiry>> GetSalesInquiriesByEmp(int userId);
        Task<List<SalesInquiry>> GetSalesInquiriesByCust(int customerId);
        Task<List<SalesInquiry>> GetSalesInquiriesByDateRange(DateTime startDate, DateTime endDate);
        Task<List<SalesInquiry>> GetSalesInquiriesByProperty(int propertyId);
        Task<SalesInquiry> GetSalesInquiry(int Id);
        Task<int> AddNewSalesInquiry(SalesInquiry inquiry);
        Task<bool> UpdateSalesInquiry(SalesInquiry inquiry);
        Task<bool> DeleteSalesInquiry(int Id);
    }
}
