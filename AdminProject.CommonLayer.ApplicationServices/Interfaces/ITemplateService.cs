using System.Collections.Generic;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Application.DTO;

namespace AdminProject.CommonLayer.Application.Interfaces
{
    public interface ITemplateService
    {
        Task<List<CommonSetupDTO>> GetTemplateCommonSetup();
    }
}
