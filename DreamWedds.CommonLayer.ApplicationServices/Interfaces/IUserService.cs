using DreamWedds.CommonLayer.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamWedds.CommonLayer.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserAlreadyExists(string email);
        Task<string> GetUserNameAsync(int userId);
        Task<UserMasterDto> GetUserAsync(int userId);
        Task<UserMasterDto> GetUserByGuidAsync(string guid); 
        Task<bool> ChangePasswordAsync(string guid, string password); 
        Task<UserMasterDto> GetUserByEmailAsync(string email);
        Task<UserMasterDto> AuthenticateUser(string userName, string password);
        Task<List<UserMasterDto>> GetAllUsers();
        Task<int> AddNewUserAsync(UserMasterDto user);
        Task UpdateUserAsync(UserMasterDto user);
        Task RemoveUserAsync(int id);

        Task<int> AssignRoleToUser(UserRolesDto userRole);
        Task RevokeRoleFromUser(int userId);
        Task<IReadOnlyList<RoleMasterDto>> GetUserRolesAsync(int userId);

        Task<IReadOnlyList<RoleMasterDto>> GetAllRolesAsync();
        Task<RoleMasterDto> GetRoleByIdAsync(int id);
        Task<int> AddNewRoleAsync(RoleMasterDto role);
        Task UpdateRoleAsync(RoleMasterDto role);
    }
}
