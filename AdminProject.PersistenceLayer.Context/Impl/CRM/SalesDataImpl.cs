using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using AdminProject.PersistenceLayer.Repository.PersistenceServices.CRM;
using AdminProject.PersistenceLayer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.Impl.CRM
{
    public class SalesDataImpl : ISalesRepository
    {
        private readonly IAsyncRepository<SalesInquiry> _salesRepository;
        private readonly AdminDbContext _dbContext;

        public SalesDataImpl(IAsyncRepository<SalesInquiry> salesRepository,
            AdminDbContext context)
        {
            _salesRepository = salesRepository;
            _dbContext = context;
        }
        public Task<int> AddNewSalesInquiry(SalesInquiry inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSalesInquiry(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiry>> GetSalesInquiries()
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiry>> GetSalesInquiriesByCust(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiry>> GetSalesInquiriesByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiry>> GetSalesInquiriesByEmp(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesInquiry>> GetSalesInquiriesByProperty(int propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<SalesInquiry> GetSalesInquiry(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSalesInquiry(SalesInquiry inquiry)
        {
            throw new NotImplementedException();
        }
    }
}
