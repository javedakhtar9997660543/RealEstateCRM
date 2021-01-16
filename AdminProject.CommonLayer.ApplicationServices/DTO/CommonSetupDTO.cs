using AutoMapper;
using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.PersistenceLayer.Entities.Entities;

namespace AdminProject.CommonLayer.Application.DTO
{
    public class CommonSetupDTO : IMapFrom<CommonSetup>
    {

        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string MainType { get; set; }
        public string SubType { get; set; }
        public int DisplayValue { get; set; }
        public int ParentID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommonSetup, CommonSetupDTO>();
            profile.CreateMap<CommonSetupDTO, CommonSetup>();
        }
    }

}
