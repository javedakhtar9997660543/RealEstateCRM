using AdminProject.PersistenceLayer.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.PersistenceServices
{
    public interface IAppMenuRepository
    {
        Task<List<Menu>> GetUserMenu(int? userId);
    }
}
