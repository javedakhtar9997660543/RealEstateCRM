using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamWedds.CommonLayer.Application.DTO
{
    public class SideBarList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string OtherInfo { get; set; }
        public int Likes { get; set; }
        public string Header { get; set; }
    }
}
