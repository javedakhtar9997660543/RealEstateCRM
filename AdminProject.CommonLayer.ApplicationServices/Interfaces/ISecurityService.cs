using System.Threading.Tasks;
using AdminProject.CommonLayer.Application.DTO;

namespace AdminProject.CommonLayer.Application.Interfaces
{
    public interface ISecurityService
    {
        Task<string> GetOtpAsync(int userId);
        Task<bool> SaveOtpAsync(OTPDto otp);
        Task<bool> ValidateGuidAsync(string guid);
    }
}
