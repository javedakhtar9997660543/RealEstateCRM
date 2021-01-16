using System;

namespace RealEstateCRM.PresentationLayer.WebApi.Model
{
    /// <summary>
    /// Base class used by API responses
    /// </summary>
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationId)
        {
            _correlationId = correlationId;
        }

        public BaseResponse()
        {
        }
    }
}
