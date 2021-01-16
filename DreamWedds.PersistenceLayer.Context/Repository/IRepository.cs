using System;
using System.Collections.Generic;
using System.Text;

namespace DreamWedds.PersistenceLayer.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
