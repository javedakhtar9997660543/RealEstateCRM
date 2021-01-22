using AdminProject.CommonLayer.Application.Mappings;
using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminProject.CommonLayer.Application.DTO
{
    public class MenuDto : BaseEntity, IMapFrom<Menu>
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Alignment { get; set; }
        [Required]
        [StringLength(750)]
        public string Path { get; set; }
        public bool Root { get; set; }
        public int Sequence { get; set; }
        public int? Title_TId { get; set; }
        [StringLength(100)]
        public string Title_TName { get; set; }
        public int? ModuleId { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        public virtual ICollection<SubMenuDto> SubMenu { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Menu, MenuDto>();
            profile.CreateMap<MenuDto, Menu>();
        }
    }

    public class SubMenuDto : BaseEntity, IMapFrom<SubMenu>
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Path { get; set; }
        [StringLength(50)]
        public string Permission { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        public int? SubTitle_TId { get; set; }
        public int? ParentId { get; set; }
        [StringLength(100)]
        public string SubTitle_TName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SubMenu, SubMenuDto>()
                 .ForMember(d => d.Title, opt => opt.MapFrom(s => s.SubTitle));

            profile.CreateMap<SubMenuDto, SubMenu>()
                 .ForMember(d => d.SubTitle, opt => opt.MapFrom(s => s.Title));
        }
    }
}
