using AdminProject.PersistenceLayer.Entities.Entities;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using AdminProject.PersistenceLayer.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.Impl
{
    public class AppMenuDataImpl : IAppMenuRepository
    {
        private readonly IAsyncRepository<Menu> _menuRepository;
        private readonly AdminDbContext _dbContext;
        private readonly IAsyncRepository<SubMenu> _subMenuRepository;

        public AppMenuDataImpl(
            IAsyncRepository<Menu> menuRepository,
            IAsyncRepository<SubMenu> subMenuRepository,
            AdminDbContext context)
        {
            _menuRepository = menuRepository;
            _subMenuRepository = subMenuRepository;
            _dbContext = context;
        }
        public async Task<List<Menu>> GetUserMenu(int? userId)
        {
            var userModules = new List<int>();
            var menu = await _dbContext.Menu.Include("SubMenu").Where(x => !x.IsDeleted).ToListAsync();
            if (userId > 0)
                userModules = await _dbContext.Set<UserRoleModulePermission>().Where(x => x.UserId == userId && !x.IsDeleted).Select(x => (int)x.ModuleId).ToListAsync();
            else
                userModules = await _dbContext.Set<ModuleMaster>().Where(x => !x.IsDeleted).Select(x => x.Id).ToListAsync();

            //if (userModules != null)
            //{
            //    var result = (from um in userModules
            //                  join mm in menu on um equals mm.ModuleId into menus
            //                  from m in menus.DefaultIfEmpty()
            //                  where m.IsDeleted == false
            //                  select new Menu
            //                  {
            //                      Title = m.Title,
            //                      Title_TId = m.Title_TId,
            //                      Title_TName = m.Title_TName,
            //                      Icon = m.Icon,
            //                      Path = m.Path,
            //                      CreatedBy = m.CreatedBy,
            //                      CreatedDate = m.CreatedDate,
            //                      ModifiedBy = m.ModifiedBy,
            //                      ModifiedDate = m.ModifiedDate,
            //                      SubMenu = m.SubMenu
            //                  }).ToList();
            //    return result;
            //}
            return menu as List<Menu>;

        }
    }
}
