using System.Linq;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateCRM.PresentationLayer.WebApi.Helpers;

namespace RealEstateCRM.PresentationLayer.WebApi.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class AppMenuController : ControllerBase
    {
        private readonly IAppMenuService _menuBusinessInstance;
        private readonly ILogger<AppMenuController> _logger;

        public AppMenuController(ILogger<AppMenuController> logger, IAppMenuService menuBusinessInstance)
        {
            _menuBusinessInstance = menuBusinessInstance;
            _logger = logger;
        }

        [HttpGet]
        [RequiresAccessTo(ApplicationTask.AllowedAccessAlways)]
        [Authorize(Policy = "TaskSecurity")]
        [Route("user-menu/{id}")]
        public async Task<IActionResult> GetUserAppMenu(int? id = 0)
        {
            var menus = await _menuBusinessInstance.GetUserMenu(id);

            if (menus.Count > 0)
            {
                var appMenu = new
                {
                    aside = new { items = menus.Where(x => x.Alignment == "LEFT"), self = string.Empty },
                    header = new { items = menus.Where(x => x.Alignment == "TOP"), self = string.Empty }
                };
                return Ok(appMenu);
            }
            throw new AppException("No Menu Item found for: " + id);
        }
    }
}