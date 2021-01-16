using Ardalis.Specification;
using AdminProject.PersistenceLayer.Entities;
using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.Repository
{
    public class Repository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly AdminDbContext _dbContext;
        public Repository(AdminDbContext context)
        {
            _dbContext = context;
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<string> GetNameByIdAsync(int id)
        {
            UserMaster result = await _dbContext.Set<UserMaster>().FirstAsync(x => x.Id == id);
            return result.FirstName;
        }


        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result;
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec);
            return await specificationResult.CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private async Task<IQueryable<T>> ApplySpecification(ISpecification<T> spec)
        {
            return await EfSpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<bool> AnyAsync(ISpecification<T> spec)
        {
            var specificationResult = await ApplySpecification(spec);
            return await specificationResult.AnyAsync();
        }

    }
}
