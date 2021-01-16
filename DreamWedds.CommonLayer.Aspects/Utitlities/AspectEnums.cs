using System;
using System.ComponentModel;
using System.Reflection;

namespace DreamWedds.CommonLayer.Aspects.Utitlities
{
    public static class AspectEnums
    {


        public enum LoginAccessType
        {
            LoginSuccess = 1,
            UnAuthorizedAccess = 2,
            Terminate = 3,
            WrongUserName = 4,
            AccountLocked = 5
        }
        /// <summary>
        /// This enum is used to define the 
        /// </summary>
        public enum Roles
        {
            FOS = 7,
            Admin = 2,
            RSCDO = 5,
            BM = 3,
            ASM = 4,
            //#region Dev Codes
            //QC1 = 89,
            //QC2 = 90,
            //Superior = 88,
            //Accessor = 91,
            //#endregion

            #region Prd role code
            Superior = 86,
            Accessor = 87,
            QC1 = 88,
            QC2 = 89,
            #endregion



        }
        /// <summary>
        /// This enum is used to define the 
        /// </summary>
        public enum IntCompInstanceNames
        {
            AndroiddNotificationManager,
            OrderManager,
        }

        /// <summary>
        /// This enum is used to define the Competition Survey Type
        /// </summary>
        public enum CompetitionSurveyType
        {
            DisplayShare = 1,
            CounterShare = 2,
        }

        /// <summary>
        /// This enum is defined to get the names of application class files used for unity container registration and resolve process
        /// </summary>
        public enum AspectInstanceNames
        {
            UserManager,
            ServiceManager,
            EmailManager,
            SecurityManager,
            WeddingManager,
            SalesCatalystManager, // By Neeraj
        }

        /// <summary>
        /// This enum is defined to get the names of application class files used for unity container registration and resolve process
        /// </summary>
        public enum PeristenceInstanceNames
        {
            EmpDataImpl,
            SystemDataImpl,
            EmailDataImpl,
            SecurityDataImpl,
            WeddingDataImpl,
        }

        /// <summary>
        /// This enum is defined to get the application name where user belongs to DataPath/TPA etc 
        /// </summary>
        public enum ApplicationName
        {
            AccuIT,
        }

        /// <summary>
        /// This enums is defined to get the config key values from app config file
        /// </summary>
        public enum ConfigKeys
        {
            Domain,
            CompanyName,
            CompanyWebsite,
            WeddingFolder,
            CompanyLogoURL,
            LatestAPKVersion,
            IsGlobalMethodLogging,
            APIKeyHeader,
            APITokenHeader,
            HostName,
            FromEmail,
            FromName,
            FileProcessorURL,
            ImagesPath,
            GoogleAndroidLoginURL,
            GoogleAndroidMessageURL,
            LoginURL,
            GeoTagCountThreshold,
            EncryptionInitVector,
            EncryptionSaltKey,
            SamsungDMSConnection,
            SchedulerConfigFile,
            EncryptionDictionary,
            ReportFileFolder,
            NoAuthorizationPage,
            SQLDBConnectionName,
            ReportDashboardWebURL,
            GCMAndroidAppID,
            GCMAndroidSenderID,
            IsBatchSchedulerOn,
            APKDownloadURL,
            IsBatchNotificationOn,
            Interval,
            HeaderUserID,
            ForgotPasswordURL,
            FotgotPasswordAttempts,
            OTPExirationHrs,
            LastAttemptDuration,
            OTPWrongAttempts,
            CORSAllowedDomains,

            USERFOLDER,


        }

        /// <summary>
        /// This enum is used to define user login status
        /// </summary>
        public enum UserLoginAttemptStatus
        {
            Successful = 0,
            WrongUserId = -1,
            InActive = -2,
            Locked = -3,
            DaysExpire = -4,
            WrongPassword = -5,
            InvalidWebUser = -9,
            SessionIdNotMatching = -10

        }

        public enum SmtpCredential
        {
            smtpHost,
            smtpUserName,
            smtpPort,
            smtpPassword,
            fromEmail,
        }

        /// <summary>
        /// This enum is used to define user login status in UserMaster
        /// </summary>
        public enum UserLoginStatus
        {
            None = 0,
            Active = 1,
            InActive = 2,
            Locked = 3,
            DaysExpire = 4,
            WrongPassword = 5,
            WrongIMEI = 6,
            MultipleIMEI = 7,
            WrongUserName = 8,
        }

        /// <summary>
        /// Main user Account Status
        /// </summary>
        public enum UserAccountStatus
        {
            Pending = 0,
            Active = 1,
            InActive = 2,
            Deleted = 3
        }

        /// <summary>
        /// This enum is used to define user reset password status
        /// </summary>
        public enum UserResetPasswordStatus
        {
            None = 0,
            Reset = 1,
            WrongEmployeeCode = 2,
            WrongIMEI = 3,
            WrongLoginName = 4,
        }

        /// <summary>
        /// This enum is used to identify the name of exception policies in application
        /// </summary>
        public enum ExceptionPolicyName
        {
            AssistingAdministrators,
            ExceptionShielding,
            LoggingAndReplacingException,
            NotifyingRethrow,
            ReplacingException,
            ServiceExceptionPolicy,
        }

        /// <summary>
        /// Enums to define the app modules
        /// </summary>
        public enum AppModules
        {
            None = 0,
            Home = 1,
            Attendance = 2,
            MarketWorking = 3,
            OfficeTraining = 4,
            PartnerMeeting = 5,
            Reports = 6,
            UserProfile = 7,
            OutletSelection = 8,
            OutletProfile = 9,
            // GeoTag = 10,
            Activity = 11,
            Collection = 12,
            Competition = 13,
            StoreOutletProfile = 14,
            HygeineAudit = 15,
            StockEsclation = 16,
            POSMTracking = 17,
            RetailAudit = 18,
            VisitorsDetail = 19,
            QuestionOfTheDay = 20,
            SchemeAvailable = 21,
            BeatManagement = 22,
            Syncing = 23,
            DisplayShare = 24,
            CounterShare = 25,
            StoreStrength = 26,
            StoreManagerRelationship = 27,
            VMQuality = 28,
            BIAudit = 30,
            BeatCreation = 32,
            BeatApproval = 33,
            //Added by Dhiraj on 09-Feb-2016 for activity report
            OrderBooking = 78,
            SelloutProjection = 79,
            GeoTagging = 113,
            EOLOrder = 89,
        }

        /// <summary>
        /// Enums to define the app modules
        /// </summary>
        public enum NotToIncludeModules
        {
            Home = 1,
            Attendance = 2,
            Competition = 13,
            OfficeTraining = 4,
            Reports = 6,
            UserProfile = 7,
            OutletSelection = 8,
            OutletProfile = 9,
            GeoTag = 10,
            Activity = 11,
            Collection = 12,
            StoreOutletProfile = 14,
            SchemeAvailable = 21,
            BeatManagement = 22,
            Syncing = 23,
            BeatCreation = 32,
            BeatApproval = 33,
        }

        /// <summary>
        /// Enum to define the web modules
        /// </summary>
        public enum WebModules
        {
            None = 0,
            UploadCSV = 100,
            CustomerDashBoard = 105,
            Wedding = 106,
            UniqueOutletCoverageDashBoard = 103,
            CompetitionBookedDashBoard = 104,
            // DisplayShareDashBoard = 105,
            CounterShareDashBoard = 106,
            HygieneAuditDashBoard = 107,
            POSMTrackingDashBoard = 108,
            BIAuditDashBoard = 109,
            VMQualityDashBoard = 110,
            SMRelationshipDashBoard = 111,
            OrderBookingDashBoard = 112,
            GeoTaggingDashBoard = 113,
            VisitorsDashBoard = 114,
            CollectionDashBoard = 115,
            SystemSettingsDashBoard = 116,
            QuestionDashBoard = 117,
            RoleDashBoard = 118,
            RoleAuthorizationDashBoard = 119,
            CompetitorDashBoard = 120,
            ModulesDashBoard = 121,
            WebModulesDashboard = 136,
            WebReportUser = 137,
            RoleQuestionsDashBoard = 122,
            MarketWorkingDashboard = 123,
            StoreStrengthDashboard = 124,
            ManageAttendence = 125,
            ManageUserProfile = 126,
            ProductBooked = 135,
            ActiveDashboard = 128,
            Announcement = 129,
            BeatExceptionManager = 130,
            Beats = 131,
            TotalCoverageNormDashBoard = 132,
            NotificationManagement = 133,
            ApkMaintanceDashboard = 134,
            MyDashboard = 127,
            //ChannelMaster = 138,
            UserStoreMapping = 142, //VC20140813
            DownloadMasterAuthorization = 143, //VC20140912
            GeoTagFreezing = 144,//VC20140924            
            ProductGroupCategory = 145, //SDCE-579 Added by Niranjan (Product Group Category) 13-10-2014
            ChannelTypeMapping = 146,  //SDCE-670 Added by Niranjan (Channel Type Mapping) 16-10-2014
            VOCUpload = 147, //SDCE-892 for VOC Upload
            VOCDownload = 148,
            CategoryMaster = 149,
            TypeMaster = 150,
            ODSchemes = 151,
            ODSchemesReport = 152,
            RaceReportMaster = 153, // Manoranjan
            VOCNewUpload = 154, // Manoranjan
            VOCReportNew = 155, // Manoranjan            
            Scheme = 156,
            MinutesOfMeeeting = 157, //Added by Neeraj for Sales Catalyst on 02-Dec-2015
            MasterDataUpload = 158, //Added by Neeraj for Sales Catalyst on 18-Dec-2015

            ApprovalPathCreation = 159,//Added for Approval path Configuration
            LeavesManager = 160,
            SalesForecast = 161// Added for LMS leave manager

        }

        /// <summary>
        /// Enum to define question types in application survey
        /// </summary>
        public enum QuestionTypes
        {
            None = 0,
            PictureBox = 1,
            Rating = 2,
            NumericText = 3,
            Textbox = 4,
            Dropdown = 5,
            RadioButton = 6,
            Checkbox = 7,
            Calendar = 8,
            ToggleButton = 9,
            Label = 10,
            NumericGrid = 11,
            TextGrid = 12,
            Repeater = 13,//added by amjad on 24 may2015
        }

        /// <summary>
        /// Enum to define Role Master Permission
        /// </summary>
        public enum RolePermissionEnums
        {
            CRUD = 1,
            View = 2,
            Update = 3,
            Delete = 4,
            Email = 5,
            Upload = 6,
        }


        // Add ModuleTypeEnum by Navneet Sharma on 3-Dec-2014 //
        /// <summary>
        /// Enum to define Module Type
        /// </summary>
        public enum ModuleTypeEnum
        {
            DashBoard = 1,
            ControlPanel = 2,
            Customer = 3
        }


        /// <summary>
        /// Enum to identify the image file types 
        /// </summary>
        public enum ImageFileTypes
        {
            None = 0,
            Survey = 1,
            Store = 2,
            User = 3,
            Training = 4,
            Question = 5,
            General = 6,
            #region for SDCE -991 (FMS) by vaishali on 27 Nov 2014
            FMS = 7,
            #endregion
            #region for dealer Creation
            DealerCreation = 8, // Added for dealer Creation SDHHP-6114 by Gourav Vishnoi 
            #endregion
            //Expense Management System
            Expense = 9

        }


        #region ExpenseManagementSystem
        /// <summary>
        /// Enum to Indentity system LMS or EMS
        /// </summary>
        public enum CheckModule
        {
            ExpenseManagementSystem = 1,
            LeaveManagementSystem = 2,
            SalesReturnSystem = 3

        }

        public enum ModuleType
        {
            Expense = 1,
            Approval_Path = 2
        }

        /// <summary>
        /// ApproverType
        /// </summary>
        public enum ApproverType
        {
            Approve = 1
            ,
            Consent = 2
                ,
            Notification = 3

           , Approval_Not_required = 4
        }

        public enum LMSLeaveType
        {
            SickLeave = 1
            , CasualLeave = 3
            , PaidLeave = 4
            , OptionalHoliday = 5
            , MedicalLeave = 6
        }

        /// <summary>
        /// Approval Status
        /// </summary>
        public enum ApprovalStatus
        {
            Sumbitted = 0
            ,
            Pending = 1
            ,
            Approved = 2
                ,
            Rejected = 3
                ,
            ApprovalNotRequired = 4,

            Cancelled = 5

            , Notification = 6
            , Consent = 7
        }

        #endregion

        /// <summary>
        /// Enum to identify the entity names for Sync tables
        /// </summary>
        public enum SyncEntitities
        {
            None = 0,
            Product = 1,
            Store = 2,
            GeoDefinition = 3,
            SurveyQuestion = 4,
            Team = 5,
            Channel = 6,
            User = 7,
            StoreUser = 8,
            UserDevice = 9,
            Regions = 10,
            Roles = 11,
        }

        /// <summary>
        /// Enum to identify pages in navigation list
        /// </summary>
        public enum NavigationList
        {
            [Description(" Attendance ")]
            Attendance = 101,
            [Description(" Attendance New ")]
            AttendanceNew = 141,
            //VC20140813
            [Description(" User Store Mapping ")]
            UserStoreMapping = 142,
            //VC20140813
            //VC20140912
            [Description(" Download Authorization ")]
            DownloadMasterAuthorization = 143,
            //VC20140912

            [Description(" Market Working ")]
            MarketWorking = 123,
            [Description(" Coverage vs Plan ")]
            TotalCoverage = 102,
            [Description(" Unique Store Coverage ")]
            UniqueOutletCoverage = 103,
            [Description(" SPP Booked ")]
            CompetitionBooked = 104,
            [Description(" Display Share ")]
            DisplayShare = 105,
            [Description(" Counter Share ")]
            CounterShare = 106,
            [Description(" Hygiene Audit ")]
            HygieneAudit = 107,
            [Description(" POSM Tracking ")]
            POSMTracking = 108,
            [Description(" BI Audit ")]
            BIAudit = 109,
            [Description(" VM Quality ")]
            VMQuality = 110,
            [Description(" SM Relationship ")]
            SMRelationship = 111,
            [Description(" Stock Escalation ")]
            OrderBooking = 112,
            [Description(" Geo Tagging ")]
            GeoTagging = 113,
            [Description(" Visitors ")]
            Visitors = 114,
            [Description(" Collection ")]
            Collection = 115,
            [Description(" System Configuration ")]
            SystemSettings = 116,
            [Description(" APK Question Master ")]
            Question = 117,
            [Description(" Excel,Mail Permission ")]
            Role = 118,
            [Description(" Module Authorisation ")]
            RoleAuthorization = 119,
            [Description(" Competitor ")]
            Competitor = 120,
            [Description(" APK Module Master ")]
            Modules = 121,
            [Description(" Console Module Master ")]
            WebModules = 136,
            [Description(" Role Questions ")]
            RoleQuestions = 122,
            [Description(" Store Strength ")]
            StoreStrength = 124,
            [Description(" Attendence Refresh ")]
            ManageAttendence = 125,
            [Description(" User Offline Exception ")]
            ManageUserProfile = 126,
            [Description(" My Report")]
            MyDashboard = 127,
            [Description(" Activity")]
            ActivityDashboard = 128,
            [Description(" Announcement")]
            Announcement = 129,
            [Description(" Beat Exception Manager")]
            BeatExceptionManager = 130,
            [Description(" Beats ")]
            Beats = 131,
            [Description(" Coverage vs Norm ")]
            TotalTotalCoverageNorm = 132,
            [Description(" Notification Management ")]
            NotificationManagement = 133,
            [Description(" APK Version Maintenance ")]
            ApkMaintanceDashboard = 134,
            [Description(" Web Report User ")]
            WebReportUser = 137,
            //[Description(" Channel Master ")]
            //ChannelMaster = 138,
            [Description(" Rule Book Upload ")]
            RuleBookUpload = 140,
            //VC20140924
            [Description(" Unfreeze Geo Tag ")]
            GeoTagFreezing = 144,
            //VC20140924
            // SDCE-579 Added by Niranjan (Product Group Category) 13-10-2014
            [Description(" Product Group Category ")]
            ProductGroupCategory = 145,
            //SDCE-670 Added by Niranjan (Channel Type Mapping) 16-10-2014
            [Description(" Channel Type Mapping ")]
            ChannelTypeMapping = 146,
            //For SDCE-892 for VOC Uplaod
            [Description(" VOC Upload ")]
            VOCUpload = 147,
            [Description(" VOC Report ")]
            VOCDownload = 148,

            // Added by Navneet (Category Master) 03-12-2014 
            [Description(" Category Master ")]
            CategoryMaster = 149,

            [Description(" Type Master ")]
            TypeMaster = 150,

        }


        /// <summary>
        /// Enum to identify Excel Master upload type: Numbered in alphabeticall order
        /// </summary>
        public enum enumExcelType
        {

            [Description(" Product Master ")]
            ProductMaster = 2,
            [Description(" Category Master ")]
            CategoryMaster = 3,
            [Description(" Product Images ")]
            ProductImages = 4,
            [Description(" Product Specifications ")]
            ProdSpecification = 5
            //[Description(" Employees")]
            //EmployeeMaster = 6,
            //[Description(" Customers")]
            //CustomerMaster = 7,
            //[Description(" Addresses")]
            //AddressMaster = 8,
            //[Description("Role Master")]
            //RoleMaster = 9
        }


        /// <summary>
        /// Enum to identify beat status
        /// </summary>
        public enum BeatStatus
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2,
        }

        /// <summary>
        /// Enum to identify mail status
        /// </summary>
        public enum EmailStatus
        {
            None = 0,
            Pending = 1,
            Failed = 2,
            Sent = 3
        }

        /// <summary>
        /// Enum to identify the channel types available in system
        /// </summary>
        public enum ChannelTypes
        {
            DISTY,
            BS,
            RR,
            RS,
            MR,
            DD,
            ED,
            SSD,
            ID,
            MBS,
            MD,
            BUD,
            SDM,
            DEALER,
        }

        /// <summary>
        /// Enum to define payment modes of collection
        /// </summary>
        public enum PaymentMode
        {
            Cash = 1,
            Cheque = 2,
            DD = 3,
            RTGS = 4,
            NEFT = 5,
            FREE = 6
        }

        /// <summary>
        /// Enum to define payment modes of collection
        /// </summary>
        public enum AnnouncementDevice
        {
            Console = 1,
            Apk = 2,
            QC = 3,

        }

        /// <summary>
        /// Enum to define the frequency type for user notifications
        /// </summary>
        public enum NotificationFrequency
        {
            None = 0,
            Hourly = 1,
            Daily = 2,
            Weekly = 3,
            Fortnightly = 4,
            Monthly = 5,
        }

        /// <summary>
        /// Enum to Define Services Names for Download Data in APK 
        /// </summary>
        public enum DownloadService
        {
            [Description(" Product ")]
            Product = 1,
            [Description(" Competitor ")]
            Competitor = 2,
            [Description(" Payment Mode ")]
            PaymentMode = 3,
            [Description(" Compition Product Group ")]
            CompitionProductGroup = 4,
            [Description(" Today's Beat ")]
            TodaysBeat = 5,
            [Description(" Other Beat ")]
            OtherBeat = 6,
            [Description(" Modules ")]
            Modules = 7,
            [Description(" Question ")]
            Question = 8,
            [Description(" Planogram ")]
            Planogram = 9,
            [Description(" Display Share ")]
            DisplayShare = 10,
            [Description(" FeedBack Management ")]
            FMS = 11,
            [Description(" End of Life Basic Model Scheme ")]
            ODScheme = 12,
            [Description(" RACE ")]
            RACE = 13,

            [Description(" Expense Master Data ")]
            ExpenseMaster = 14
        }

        public enum CoverageType
        {
            [Description(" Coverage vs Norm ")]
            CoverageVsNorm = 1,
            [Description(" Coverage vs Plan  ")]
            CoverageVsPlan = 2,
            [Description(" Unique Coverage ")]
            UniqueCoverage = 3,
        }
        public enum CoverageReportType
        {
            [Description(" MyDashboard ")]
            MyDashboard = 1,
            [Description(" Coverage ")]
            Coverage = 2,

        }
        #region for SDCE -991 (FMS) by vaishali on 02 Dec 2014
        public enum NotificationType
        {
            CustomNotificationManagement = 1,
            Beat = 2,
            Coverage = 3,
            FMS = 4,
            SCM = 5,
            EPOS = 6,
            SOP = 7,
            SALES = 8,
            NewDealer = 9
        }
        public enum FMSStatusIDs
        {
            PendingforETR = 1,
            PendingforRFC = 2,
            PendingForClosure = 3,
            Closed = 4,
            PendingforETR2 = 5,
            PendingforRFC2 = 6,
            PendingForClosure2 = 7,
            ClosedwithAggree = 8,
            ClosedwithDisagree = 9,
            ViewAll = 0
        }
        public enum RowCounter
        {
            FMSRowCounter = 100,
            RACERowCounter = 100,
        }
        #endregion
        #region for SDCE-1082
        public enum FMSNotificationSubType
        {
            Em1 = 1,
            Em2 = 2,
            HO = 3,
            SPOC = 4,
            User = 5
        }

        public enum NotificationAttribute3
        {
            FMSWithinTAT = 0,
            FMSOutOfTAT = 1,
            FMSSpocNotDefined = 2,
        }

        #endregion

        public enum RoleCode
        {
            [Description("VOC-MANAGER")]
            VOCManager,
        }

        public enum RoleType
        {
            Admin = 1,
            Employee = 2,
            Customer = 3
        }

        public enum UserValidationType
        {
            [Description("Validate only Employee Code")]
            EmplCode = 1,
            [Description("Validate Employee  Email ID")]
            EmplEmail = 2,
            ForgotPasswordAttempts = 3,
            LastAttemptDuration = 4
        }

        public enum CommonTableMainType
        {
            Template = 1,
            Module = 2,
            Address = 3,
            Wedding = 4
        }
        public enum TemplateType
        {
            Register = 1,
            ResetPassword = 2,
            AutoReply = 3,
            Marketing = 4,
            Sales = 5,
            Festive = 6,
            Invoice = 7,
            Reminder = 8,
            Acknowledgement = 9
        }

        public enum EmailTemplateCode
        {
            ResetPassword = 101,
            ContactUsReply = 102,
            AutoReply = 3,
            WelcomeEmail = 103,
            ThankYouEmail = 5
        }

        public enum CommonFieldSubType
        {
            Style,
            Relation,
            Features
        }

        public enum OrderStatus
        {
            Confirmed = 1,
            Submitted = 2,
            Cancelled = 3,
            Refunded = 4
        }

        public enum SubscriptionType
        {
            Annual = 1,
            HalfYearly = 2,
            Quarterly = 3,
            Monthly = 4,
            Weekly = 5,
            Trial = 6,
        }

        public enum WeddingStyle
        {
            Anonymous = 0,
            Hindu = 1,
            Muslim = 2,
            Christian = 3,
            Punjabi = 4,
            Western = 5
        }

        public enum SubscriptionStatus
        {
            Active = 1,
            InActive = 2,
            Hold = 3,
            Cancelled = 4,
        }

        public enum TemplateStatus
        {
            Active = 1,
            InActive = 2,
            InDevelopment = 3,
            Live = 4
        }

        public enum AddressType
        {
            Residential = 1,
            Official = 2,
            PartyHall = 3

        }
        public enum AddressOwnerType
        {
            User = 1,
            Venue = 3,
            GroomAndMen = 4,
            BrideAndMaids = 5
        }

        public enum Relatives
        {
            Father = 1,
            Mother = 2,
            Brother = 3,
            Sister = 4,
            GrandFather = 5,
            GrandMother = 6,
            Friend = 7
        }

        #region to identify ActionType of an entity
        /*
         Created By     ::      Vaishali Choudhary
         Created Date   ::      11 March 2015         
         */
        public enum EntityActionType
        {
            Insert = 1,
            Update = 2,
        }

        public enum ODScheme
        {
            Create = 1,
            Update = 2,
            OrderSubmit = 3,
            SchemeExpire = 4,
        }

        /// <summary>
        /// identity the type of interface (Web, exe etc..)
        /// </summary>
        public enum InterfaceType
        {
            Web = 1,
            exe = 2,
        }
        #endregion

        #region Race audit status on 09 June 2015 by Vaishali (SDCE-1750)
        public enum RaceAuditStatus
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2,
            Comments = 3
        }

        public enum RaceAuditStatusText
        {
            [Description("Pending")]
            Pending = 0,
            [Description("Approved")]
            Approved = 1,
            [Description("Rejected")]
            Rejected = 2,
            [Description("Comments")]
            Comments = 3
        }
        #endregion

        #region LMS Enums
        public enum LMSSearchAction
        {
            Submitted = 1,
            Others = 2,
        }
        #endregion

    }

    public static class GetEnumDescription
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
            /* how to use
                MyEnum x = MyEnum.NeedMoreCoffee;
                string description = x.GetDescription();
            */

        }
    }

}
