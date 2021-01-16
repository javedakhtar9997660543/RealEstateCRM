using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AdminProject.PersistenceLayer.Entities.Common;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class UserSettings : BaseEntity, IAggregateRoot
    {

        [ForeignKey("UserId")]
        public virtual UserMaster User { get; set; }

        [Column("COLCHARACTER")]
        public string CharacterValue { get; set; }

        [Column("COLINTEGER")]
        public int? IntegerValue { get; set; }

        [Column("COLBOOLEAN")]
        public bool? BooleanValue { get; set; }

        [Column("COLDECIMAL")]
        public decimal? DecimalValue { get; set; }

        [ForeignKey("SettingId")]
        public virtual SettingDefinition Definition { get; set; }
    }

    public class SettingDefinition : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? NameTid { get; set; }
        public int? DescriptionTid { get; set; }
        public virtual ICollection<UserSettings> UserSettings { get; set; }
    }

    public static class KnownSettingIds
    {
        public const int IsExchangeInitialised = 1;
        public const int AreExchangeAlertsRequired = 2;
        public const int ExchangeMailbox = 3;
        public const int DisplayOutlookReminders = 4;
        public const int ExchangeAlertTime = 5;
        public const int PreferredCulture = 6;
        public const int HideContinuedEntries = 18;
        public const int DefaultEventNoteType = 25;
        public const int PreferredTwoFactorMode = 26;
        public const int EmailSecretKey = 27;
        public const int AppSecretKey = 28;
        public const int AppTempSecretKey = 29;
        public const int DisplayTimeWithSeconds = 19;
        public const int ResetPasswordSecretKey = 30;
        public const int AddEntryOnSave = 31;
        public const int TimeFormat12Hours = 32;
        public const int ContinueFromCurrentTime = 21;
        public const int ValueTimeOnEntry = 33;
        public const int WorkSiteLogin = 9;
        public const int WorkSitePassword = 10;
        public const int SearchReportGenerationTimeout = 34;
        public const int BillingWorksheetReportPushtoBackgroundTimeout = 24;
        public const int UseImanageWorkLink = 35;
    }

}
