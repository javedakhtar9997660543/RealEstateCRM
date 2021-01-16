using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DreamWedds.CommonLayer.Application.Mappings;
using DreamWedds.PersistenceLayer.Entities.Entities;

namespace DreamWedds.CommonLayer.Application.DTO
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
