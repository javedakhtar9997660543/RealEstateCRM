using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.PersistenceLayer.Entities.Entities;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminProject.BusinessLayer.ServiceManager
{
    public class AppMenuServiceManager : IAppMenuService
    {
        private readonly IAppMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public AppMenuServiceManager(IAppMenuRepository menuRepository, IMapper mapper)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuDto>> GetUserMenu(int? userId)
        {
            var menu = await _menuRepository.GetUserMenu(userId);
            return _mapper.Map<List<Menu>, List<MenuDto>>(menu);
        }
    }
}
