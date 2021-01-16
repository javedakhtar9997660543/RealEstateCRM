using System;

namespace AdminProject.CommonLayer.ApplicationServices.Impl
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
