using System;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class DailyLoginHistory
    {
        [Obsolete("For persistence only.")]
        public DailyLoginHistory()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login")]
        public DailyLoginHistory(int userId, string provider, string application, DateTime loginTime)
        {
            UserId = userId;
            Provider = provider;
            LoginTime = loginTime;
            Application = application;
        }
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string Provider { get; private set; }
        public string Application { get; set; }
        public string Source { get; set; }
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
        public string BrowserName { get; set; }
        public int? LoginType { get; set; }
        public DateTime? LogOutTime { get; set; }
        public DateTime? LastExtension { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool IsLogin { get; set; }

        public UserMaster User { get; set; }
    }
}
