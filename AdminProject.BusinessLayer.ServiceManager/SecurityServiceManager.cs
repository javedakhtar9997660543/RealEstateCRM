using System;
using System.Threading.Tasks;
using AutoMapper;
using AdminProject.CommonLayer.Application.DTO;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Entities;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;

namespace AdminProject.BusinessLayer.ServiceManager
{
    public class SecurityServiceManager : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IMapper _mapper;

        public SecurityServiceManager(IMapper mapper, ISecurityRepository securityRepository)
        {
            _mapper = mapper;
            _securityRepository = securityRepository;
        }
        public async Task<string> GetOtpAsync(int userId)
        {
            var uniqueString = AppUtil.GetUniqueGuidString();
            string otpString = AppUtil.GetUniqueRandomNumber(100000, 999999); // Generate a Six Digit OTP
            var otp = new OtpMaster { Guid = uniqueString, Otp = otpString, CreatedDate = DateTime.Now, UserId = userId, Attempts = 0 };

            if (await _securityRepository.SaveOtpAsync(otp)) return uniqueString;

            return string.Empty;
        }

        public async Task<bool> SaveOtpAsync(OTPDto otp)
        {
            var otpmaster = _mapper.Map<OTPDto, OtpMaster>(otp);
            return await _securityRepository.SaveOtpAsync(otpmaster);
        }

        public async Task<bool> ValidateGuidAsync(string guid)
        {
            return await _securityRepository.ValidateGuidAsync(guid);
        }
    }
}