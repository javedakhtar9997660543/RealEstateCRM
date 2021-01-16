using System.Collections.Generic;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Application.Model.Security;
using AdminProject.PersistenceLayer.Entities.Entities;

namespace AdminProject.PersistenceLayer.Repository.PersistenceServices
{
    public interface ISecurityRepository
    {
        Task<bool> SaveOtpAsync(OtpMaster otp);
        Task<bool> ValidateGuidAsync(string guid);

        IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null);
    }
}
