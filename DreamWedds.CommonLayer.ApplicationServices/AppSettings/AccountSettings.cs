using System;
using System.Collections.Generic;
using System.Text;

namespace DreamWedds.CommonLayer.Application.AppSettings
{
    public class AccountSettings
    {
        public string ForgotPasswordUrl { get; set; }
        public int ForgotPasswordAttempts { get; set; }
        public int OTPExpirationHrs { get; set; }
        public string LastAttemptDuration { get; set; }
    }
}
