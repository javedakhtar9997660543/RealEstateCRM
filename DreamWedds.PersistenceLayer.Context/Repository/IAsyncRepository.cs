using Ardalis.Specification;
using DreamWedds.PersistenceLayer.Entities;
using DreamWedds.PersistenceLayer.Entities.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamWedds.PersistenceLayer.Repository.Repository
{
    public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<string> GetNameByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(ISpecification<T> spec);
    }
}
