using System;
using AdminProject.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Specifications;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using AdminProject.PersistenceLayer.Repository.Repository;

namespace AdminProject.PersistenceLayer.Repository.Impl
{
    public class UserDataImpl : IUserRepository
    {
        private readonly IAsyncRepository<UserMaster> _userRepository;
        private readonly AdminDbContext _dbContext;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IAsyncRepository<RoleMaster> _roleRepository;

        public UserDataImpl(IAsyncRepository<UserMaster> userRepository,
            IAsyncRepository<UserRoles> userRoleRepository,
            IAsyncRepository<RoleMaster> roleRepository,
            AdminDbContext context)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _dbContext = context;
        }

        public async Task<IReadOnlyList<UserMaster>> GetAllUsers()
        {
            return await _userRepository.ListAllAsync();
        }

        public async Task<UserMaster> GetById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserMaster> AuthenticateUser(string userName, string password)
        {
            var user = await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.Email == userName && x.Password == password) ??
                       await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return user;
        }

        public async Task<UserMaster> GetUserAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserMaster> GetUserByGuidAsync(string guid)
        {
            var objOtp = await _dbContext.OtpMaster.AsNoTracking().FirstOrDefaultAsync(x => x.Guid == guid);
            if (objOtp == null) return null;

            return await _userRepository.GetByIdAsync(objOtp.UserId);
        }

        public async Task<bool> ChangePasswordAsync(string guid, string password)
        {
            int otpExirationHrs = Convert.ToInt32(AppUtil.GetAppSettings(AspectEnums.ConfigKeys.OTPExirationHrs));
            var startTime = DateTime.Now.Subtract(new TimeSpan(otpExirationHrs, 0, 0));
            var endTime = DateTime.Now;

            var objOtp = await _dbContext.OtpMaster.FirstOrDefaultAsync(k => k.CreatedDate >= startTime && k.CreatedDate <= endTime && k.Guid == guid);
            if (objOtp == null) return false;

            var user = await _userRepository.GetByIdAsync(objOtp.UserId);
            await _userRepository.UpdateAsync(user);
            //Delete all previous OTPs
            foreach (var o in await _dbContext.OtpMaster.Where(k => k.UserId == user.Id).ToListAsync())
                _dbContext.OtpMaster.Remove(o);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<UserMaster> GetUserByEmailAsync(string email)
        {
            var specification = new UserFilterSpecification(email);
            var user = await _userRepository.FirstAsync(specification);
            return user;
        }

        public async Task<string> GetUserNameAsync(int userId)
        {
            return await _userRepository.GetNameByIdAsync(userId);
        }

        public async Task<int> AddNewUserAsync(UserMaster user)
        {
            var newUser = await _userRepository.AddAsync(user);
            return newUser.Id;
        }

        public async Task UpdateUserAsync(UserMaster user)
        {
            var u = await _userRepository.GetByIdAsync(user.Id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.AccountStatus = user.AccountStatus;
            u.Mobile = user.Mobile;
            u.Phone = user.Phone;
            u.Password = user.Password;
            u.Email = user.Email;
            u.UserName = user.UserName;
            u.Image = user.Image;
            u.IsEmployee = user.IsEmployee;
            u.EmpCode = user.EmpCode;
            await _userRepository.UpdateAsync(u);
        }

        public async Task<int> AssignRoleToUser(UserRoles userRole)
        {
            userRole.IsActive = true;
            var ur = await _userRoleRepository.AddAsync(userRole);
            return ur.Id;
        }

        public async Task RevokeRoleFromUser(int userId)
        {
            var r = await _dbContext.UserRoles.Where(x => x.UserId == userId).ToListAsync();
            if (r.Count > 0)
            {
                foreach (var item in r)
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                    await _userRoleRepository.UpdateAsync(item);
                }
            }
        }

        public async Task<IReadOnlyList<RoleMaster>> GetUserRolesAsync(int userId)
        {
            var result = await (from ur in _dbContext.UserRoles
                                join r in _dbContext.RoleMaster on ur.RoleId equals r.Id
                                where ur.UserId == userId
                                select new RoleMaster
                                {
                                    RoleDescription = r.RoleDescription,
                                    IsAdmin = r.IsAdmin,
                                    Name = r.Name
                                }).ToListAsync();

            return result;
        }

        public async Task<IReadOnlyList<RoleMaster>> GetAllRolesAsync()
        {
            return await _roleRepository.ListAllAsync();
        }

        public async Task<RoleMaster> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewRoleAsync(RoleMaster role)
        {
            var newRole = await _roleRepository.AddAsync(role);
            return newRole.Id;
        }

        public async Task UpdateRoleAsync(RoleMaster role)
        {
            var r = await _roleRepository.GetByIdAsync(role.Id);
            r.RoleDescription = role.RoleDescription;
            r.Name = role.Name;
            r.IsAdmin = role.IsAdmin;
            r.Code = role.Code;
            await _roleRepository.UpdateAsync(r);
        }
    }
}
