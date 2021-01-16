using System.Threading.Tasks;
using DreamWedds.CommonLayer.Application.DTO;

namespace DreamWedds.CommonLayer.Application.Interfaces
{
    public interface ISecurityService
    {
        Task<string> GetOtpAsync(int userId);
        Task<bool> SaveOtpAsync(OTPDto otp);
        Task<bool> ValidateGuidAsync(string guid);
    }
}
