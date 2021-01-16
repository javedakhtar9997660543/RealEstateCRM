using System.Threading.Tasks;
using AdminProject.PresentationLayer.WebApi.Helpers;
using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.Aspects.Extensions;
using AdminProject.CommonLayer.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace AdminProject.PresentationLayer.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userBusinessInstance;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userBusinessInstance)
        {
            _userBusinessInstance = userBusinessInstance;
            _logger = logger;
        }


        [HttpGet]
        [RequiresAccessTo(ApplicationTask.AllowedAccessAlways)]
        [Authorize(Policy = "TaskSecurity")]
        [Route("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userId = User.GetLoggedInUserId<string>();
            var user = await _userBusinessInstance.GetAllUsers();
            if (user == null) throw new AppException("No User found for: " + userId);

            return Ok(user);

        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult> GetUserById(int userId)
        {
            if (userId == 0) return BadRequest();

            var item = await _userBusinessInstance.GetUserAsync(userId);
            if (item is null) return NotFound();

            return Ok(item);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddNewUser([FromBody] UserMasterDto user)
        {
            if (user == null) return BadRequest();
            var userExists = await _userBusinessInstance.IsUserAlreadyExists(user.Email);
            if (userExists) throw new AppException("User with email address: " + user.Email + " already registered with us. Please follow the email we sent now.");

            var id = await _userBusinessInstance.AddNewUserAsync(user);
            return Ok(id);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateExistingUser([FromBody] UserMasterDto user)
        {
            if (user == null) return BadRequest();

            await _userBusinessInstance.UpdateUserAsync(user);
            return Ok();

        }

        [HttpGet("remove/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveExistingUser(int id)
        {
            if (id == 0) return BadRequest();

            await _userBusinessInstance.RemoveUserAsync(id);
            return Ok();
        }
    }
}
