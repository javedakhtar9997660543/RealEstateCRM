using System;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public int Priority { get; set; }
        public int Severity { get; set; }
        public string Title { get; set; }
        public string MachineName { get; set; }
        public string AppDomainName { get; set; }
        public string ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ThreadName { get; set; }
        public string Win32ThreadId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string FormattedMessage { get; set; }
    }
}
