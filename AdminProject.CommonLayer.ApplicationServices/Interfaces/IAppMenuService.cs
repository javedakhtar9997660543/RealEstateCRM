using AdminProject.CommonLayer.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminProject.CommonLayer.Application.Interfaces
{
    public interface IAppMenuService
    {
        Task<List<MenuDto>> GetUserMenu(int? userId);
    }
}
