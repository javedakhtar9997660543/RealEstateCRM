using AutoMapper;
using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities;

namespace AdminProject.CommonLayer.Application.DTO
{
    public class UserRolesDto : BaseEntity, IMapFrom<UserRoles>, IMapFrom<RoleMaster>
    {
        public int RoleId { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoleMaster, UserRolesDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Name));
            profile.CreateMap<UserRolesDto, UserRoles>();
            profile.CreateMap<UserRoles, UserRolesDto>();
        }
        public virtual RoleMasterDto Role { get; set; }
        public virtual UserMasterDto User { get; set; }
    }
}
