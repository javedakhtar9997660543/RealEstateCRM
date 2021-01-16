using System.Collections.Generic;
using System.Threading.Tasks;
using DreamWedds.CommonLayer.Application.Model.Security;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.PersistenceLayer.Repository.PersistenceServices
{
    public interface ISecurityRepository
    {
        Task<bool> SaveOtpAsync(OtpMaster otp);
        Task<bool> ValidateGuidAsync(string guid);

        IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null);
    }
}
