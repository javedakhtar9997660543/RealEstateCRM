
using AdminProject.PersistenceLayer.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminProject.PersistenceLayer.Repository.PersistenceServices
{
    public interface IUserRepository
    {
        Task<UserMaster> GetUserAsync(int id);
        Task<UserMaster> GetUserByEmailAsync(string email);
        Task<UserMaster> GetUserByGuidAsync(string guid);
        Task<bool> ChangePasswordAsync(string guid, string password); 
        Task<IReadOnlyList<UserMaster>> GetAllUsers();
        Task<UserMaster> AuthenticateUser(string userName, string password);
        Task<int> AddNewUserAsync(UserMaster user);
        Task UpdateUserAsync(UserMaster user);

        Task<int> AssignRoleToUser(UserRoles userRole);
        Task RevokeRoleFromUser(int userId);
        Task<IReadOnlyList<RoleMaster>> GetUserRolesAsync(int userId);

        Task<IReadOnlyList<RoleMaster>> GetAllRolesAsync();
        Task<RoleMaster> GetRoleByIdAsync(int id);
        Task<int> AddNewRoleAsync(RoleMaster role);
        Task UpdateRoleAsync(RoleMaster role);
    }
}
