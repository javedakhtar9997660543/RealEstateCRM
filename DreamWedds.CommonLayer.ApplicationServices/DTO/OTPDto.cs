using System;

namespace DreamWedds.CommonLayer.Application.DTO
{
    public class OTPDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Guid { get; set; }
        public string Otp { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Attempts { get; set; }
    }
}
