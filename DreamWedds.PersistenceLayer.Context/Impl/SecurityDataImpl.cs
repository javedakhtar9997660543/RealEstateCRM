using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamWedds.CommonLayer.Application.AppSettings;
using DreamWedds.CommonLayer.Application.Model.Security;
using DreamWedds.CommonLayer.Aspects.Extensions;
using DreamWedds.CommonLayer.Aspects.Utitlities;
using DreamWedds.PersistenceLayer.Entities.Entities;
using DreamWedds.PersistenceLayer.Repository.PersistenceServices;
using DreamWedds.PersistenceLayer.Repository.Repository;
using DreamWedds.PersistenceLayer.Repository.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DreamWedds.PersistenceLayer.Repository.Impl
{
    public class SecurityDataImpl : ISecurityRepository
    {
        //readonly Func<DateTime> _clock;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AdminDbContext _dbContext;
        private readonly IAsyncRepository<UserMaster> _userRepository;
        private readonly AccountSettings _accountSettings;
        readonly ITaskSecurityProviderCache _taskSecurityProviderCache;
        public SecurityDataImpl(AdminDbContext dbContext, IAsyncRepository<UserMaster> userRepository, IOptions<AccountSettings> accountSettings, IHttpContextAccessor httpContextAccessor, ITaskSecurityProviderCache taskSecurityProviderCache)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _taskSecurityProviderCache = taskSecurityProviderCache;
            // _clock = clock;
            _accountSettings = accountSettings.Value;
        }

        public async Task<bool> SaveOtpAsync(OtpMaster otp)
        {
            bool isSuccess = false;
            // In case from Generating OTP from Automatic redirect to Change Password because of not complex password multiple OTPs can be generated
            // Use this validation to restrict user to generate multiple OTPs
            if (await ValidateUser(otp.UserId, AspectEnums.UserValidationType.LastAttemptDuration))
            {
                _dbContext.Entry(otp).State = EntityState.Added;
                isSuccess = await _dbContext.SaveChangesAsync() > 0;
            }
            return isSuccess;
        }

        public IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null)
        {
            return AvailableTasks(userId).Values;
        }

        IDictionary<short, ValidSecurityTask> AvailableTasks(int? userId = null)
        {
            var identityId = userId ?? _httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>();
            var result = _taskSecurityProviderCache.Resolve(x =>
            {
                return AvailableTasksFromDb(identityId)
                    .ToDictionary(k => k.TaskId, v => v);
            }, identityId);

            return result;
        }

        IEnumerable<ValidSecurityTask> AvailableTasksFromDb(int userId)
        {
            //var today = _clock().Date;

            var task = new PermissionsGrantedItem { ObjectIntegerKey = -2, CanDelete = false, CanExecute = true, CanInsert = false, CanUpdate = true};
            var tasks = new List<PermissionsGrantedItem>();
            tasks.Add(task);
            var result = new List<ValidSecurityTask>();
            foreach (var t in tasks)
            {
                var tk = new ValidSecurityTask
                {
                    TaskId = (short) t.ObjectIntegerKey,
                    CanInsert = t.CanInsert,
                    CanUpdate = t.CanUpdate,
                    CanDelete = t.CanDelete,
                    CanExecute = t.CanExecute
                };
                result.Add(tk);
            }

            return result;
        }

        public async Task<bool> ValidateGuidAsync(string guid)
        {
            var otpExpirationHrs = _accountSettings.OTPExpirationHrs;

            var startTime = DateTime.Now.Subtract(new TimeSpan(otpExpirationHrs, 0, 0));
            var endTime = DateTime.Now.AddMinutes(1);
            var objOtp = await _dbContext.OtpMaster.FirstOrDefaultAsync(k =>
                k.CreatedDate >= startTime && k.CreatedDate <= endTime && k.Guid == guid);
            return objOtp != null;
        }

        public async Task<bool> ValidateUser(int userId, AspectEnums.UserValidationType type)
        {
            var isValid = false;
            UserMaster user = null;

            switch (type)
            {
                case AspectEnums.UserValidationType.EmplEmail:
                    user = _dbContext.UserMaster.FirstOrDefault(k =>
                        k.Id == userId && !k.IsDeleted && !string.IsNullOrEmpty(k.Email));
                    break;
                case AspectEnums.UserValidationType.ForgotPasswordAttempts:
                {
                    var today = DateTime.Today;
                    var tomorrow = DateTime.Today.AddDays(1);
                    var user1 = await _userRepository.GetByIdAsync(userId);
                    // Check Max Attempts
                    var todayAttempts = _dbContext.OtpMaster.Count(k =>
                        k.Id == userId && k.CreatedDate >= today && k.CreatedDate < tomorrow);
                    if (user1 != null)
                    {
                        var passwordAttempts = _accountSettings.ForgotPasswordAttempts;
                        isValid = todayAttempts < passwordAttempts;
                    }

                    break;
                }
                case AspectEnums.UserValidationType.LastAttemptDuration:
                {
                    var now = DateTime.Now;
                    var user1 = await _userRepository.GetByIdAsync(userId);
                    // Check Last Attempt
                    if (user1 != null)
                    {
                        var lastAttemptDuration = _accountSettings.LastAttemptDuration;
                        var timeArr = lastAttemptDuration.Split(':');

                        var lastAttemptStart = now.Subtract(new TimeSpan(int.Parse(timeArr[0]), int.Parse(timeArr[1]),
                            int.Parse(timeArr[2])));

                        var valid = await _dbContext.OtpMaster.AnyAsync(k =>
                            k.Id == userId && k.CreatedDate >= lastAttemptStart && k.CreatedDate < now);
                        isValid = !valid;
                    }

                    break;
                }
            }

            if (user != null)
                isValid = true;

            return isValid;
        }
    }
}