using System;

namespace RealEstateCRM.PresentationLayer.WebApi.Model
{
    public class AuthenticateResponse : BaseResponse
    {
        public AuthenticateResponse(Guid correlationId) : base(correlationId)
        {
        }

        public AuthenticateResponse()
        {
        }

        public bool IsSuccess { get; set; }
        public int ExpiresIn { get; set; }
        public string Token { get; set; }
    }
}
