using System;
using System.Collections.Generic;

namespace AdminProject.PresentationLayer.WebApi.Model
{
    public class JsonResponse<T> : BaseResponse
    {
        public JsonResponse(Guid correlationId) : base(correlationId)
        {
        }

        public JsonResponse()
        {
        }

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<T> Result { get; set; }

        public T SingleResult { get; set; }
    }
}
