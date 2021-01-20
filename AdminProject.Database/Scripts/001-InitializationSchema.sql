USE [master]
GO
/****** Object:  Database [CRMDb]    Script Date: 1/20/2021 6:28:35 PM ******/
CREATE DATABASE [CRMDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRMDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CRMDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRMDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CRMDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CRMDb] SET COMPATIBILITY_LEVEL = 130
GO

USE [CRMDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CRMDb]
GO
/****** Object:  Table [dbo].[AddressMaster]    Script Date: 1/20/2021 6:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Address1] [nvarchar](250) NULL,
	[Address2] [nvarchar](250) NULL,
	[City] [int] NOT NULL,
	[State] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[PinCode] [nvarchar](6) NULL,
	[AddressType] [int] NULL,
	[AddressStatus] [int] NULL,
	[UserId] [int] NULL,
	[OwnerType] [int] NULL,
	[Lattitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
	[CustomerId] [int] NULL,
	[GoogleMpsUrl] [nvarchar](1500) NULL,
	[Landmark] [nvarchar](50) NULL,
	[BuilderMasterId] [int] NULL,
 CONSTRAINT [PK_AddressMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 1/20/2021 6:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Subject] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[DurationMins] [int] NULL,
	[AppointmentDate] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[NotificationSentTime] [datetime2](7) NOT NULL,
	[NotificationSentBy] [int] NOT NULL,
	[MeetingNotes] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[CustomerId] [int] NULL,
	[AppointmentId] [int] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuilderMaster]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuilderMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[EstablishmentYear] [datetime2](7) NOT NULL,
	[CompletedProjectsCount] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_BuilderMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuilderProperties]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuilderProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuilderId] [int] NULL,
	[PropertyId] [int] NULL,
 CONSTRAINT [PK_BuilderProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CommonSetup]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommonSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MainType] [nvarchar](max) NULL,
	[SubType] [nvarchar](max) NULL,
	[DisplayText] [nvarchar](max) NULL,
	[DisplayValue] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_CommonSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyMaster]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[DivisionId] [int] NOT NULL,
 CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[ContactFor] [int] NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[COUNTRYCODE] [nvarchar](3) NOT NULL,
	[COUNTRY] [nvarchar](max) NULL,
	[COUNTRY_TID] [int] NULL,
	[COUNTRYADJECTIVE] [nvarchar](max) NULL,
	[POSTCODEFIRST] [decimal](18, 2) NULL,
	[POSTCODELITERAL] [nvarchar](max) NULL,
	[POSTCODELITERAL_TID] [int] NULL,
	[POSTALNAME] [nvarchar](max) NULL,
	[STATEABBREVIATED] [decimal](18, 2) NULL,
	[ADDRESSSTYLE] [int] NULL,
	[NAMESTYLE] [int] NULL,
	[AllMembersFlag] [decimal](9, 4) NOT NULL,
	[RECORDTYPE] [nvarchar](max) NULL,
	[ALTERNATECODE] [nvarchar](max) NULL,
	[COUNTRYABBREV] [nvarchar](max) NULL,
	[INFORMALNAME] [nvarchar](max) NULL,
	[ISD] [nvarchar](max) NULL,
	[PRIORARTFLAG] [bit] NULL,
	[NOTES] [nvarchar](max) NULL,
	[DATECOMMENCED] [datetime2](7) NULL,
	[DATECEASED] [datetime2](7) NULL,
	[WORKDAYFLAG] [smallint] NULL,
	[INFORMALNAME_TID] [int] NULL,
	[COUNTRYADJECTIVE_TID] [int] NULL,
	[POSTALNAME_TID] [int] NULL,
	[NOTES_TID] [int] NULL,
	[STATELITERAL] [nvarchar](max) NULL,
	[STATELITERAL_TID] [int] NULL,
	[PostCodeAutoFlag] [decimal](9, 4) NULL,
	[POSTCODESEARCHCODE] [int] NULL,
	[DEFAULTTAXCODE] [nvarchar](450) NULL,
	[DEFAULTCURRENCY] [nvarchar](450) NULL,
	[REQUIREEXEMPTTAXNO] [decimal](9, 4) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[COUNTRYCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CountryGroup]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryGroup](
	[TREATYCODE] [nvarchar](150) NOT NULL,
	[MEMBERCOUNTRY] [nvarchar](150) NOT NULL,
	[PROPERTYTYPES] [nvarchar](max) NULL,
	[DATECOMMENCED] [datetime2](7) NULL,
	[DATECEASED] [datetime2](7) NULL,
	[ASSOCIATEMEMBER] [decimal](9, 4) NULL,
	[DEFAULTFLAG] [decimal](9, 4) NULL,
	[PREVENTNATPHASE] [bit] NULL,
	[FULLMEMBERDATE] [datetime2](7) NULL,
	[ASSOCIATEMEMBERDATE] [datetime2](7) NULL,
 CONSTRAINT [PK_CountryGroup] PRIMARY KEY CLUSTERED 
(
	[TREATYCODE] ASC,
	[MEMBERCOUNTRY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CURRENCY] [nvarchar](450) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[DESCRIPTION_TID] [int] NULL,
	[SellRate] [decimal](9, 4) NULL,
	[DECIMALPLACES] [tinyint] NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CURRENCY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[AccountStatus] [int] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[AltMobile] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Linkedin] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[ReferredByUserId] [int] NULL,
	[ReferenceSource] [int] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DailyLoginHistory]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyLoginHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[SessionId] [nvarchar](max) NULL,
	[IpAddress] [nvarchar](max) NULL,
	[BrowserName] [nvarchar](max) NULL,
	[LoginType] [int] NULL,
	[LogOutTime] [datetime2](7) NULL,
	[LoginTime] [datetime2](7) NULL,
	[IsLogin] [bit] NOT NULL,
	[Application] [nvarchar](max) NULL,
	[LastExtension] [datetime2](7) NULL,
	[Provider] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
 CONSTRAINT [PK_DailyLoginHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailMergeFields]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailMergeFields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[FieldName] [nvarchar](max) NULL,
	[SrcField] [nvarchar](max) NULL,
	[SrcFieldValue] [nvarchar](max) NULL,
	[Sequence] [int] NULL,
	[TemplateCode] [int] NULL,
	[EmailTemplateId] [int] NULL,
 CONSTRAINT [PK_EmailMergeFields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailService]    Script Date: 1/20/2021 6:28:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailService](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NOT NULL,
	[FromEmail] [nvarchar](max) NULL,
	[FromName] [nvarchar](max) NULL,
	[ToName] [nvarchar](max) NULL,
	[ToEmail] [nvarchar](max) NULL,
	[CcEmail] [nvarchar](max) NULL,
	[BccEmail] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[IsHtml] [bit] NOT NULL,
	[Priority] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsAttachment] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AttachmentFileName] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[TemplateCode] [int] NULL,
 CONSTRAINT [PK_EmailService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailTemplate]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[HtmlContent] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Cost] [int] NULL,
	[AuthorName] [nvarchar](max) NULL,
	[About] [nvarchar](max) NULL,
	[TemplateCode] [int] NULL,
 CONSTRAINT [PK_EmailTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[Priority] [int] NOT NULL,
	[Severity] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[MachineName] [nvarchar](max) NULL,
	[AppDomainName] [nvarchar](max) NULL,
	[ProcessId] [nvarchar](max) NULL,
	[ProcessName] [nvarchar](max) NULL,
	[ThreadName] [nvarchar](max) NULL,
	[Win32ThreadId] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[FormattedMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginAttemptHistory]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginAttemptHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FailedAttempt] [int] NULL,
	[UserId] [int] NOT NULL,
	[LoginDate] [datetime2](7) NULL,
	[LastLoginDate] [datetime2](7) NULL,
	[IpAddress] [nvarchar](max) NULL,
	[Browser] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoginAttemptHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModuleMaster]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[ParentModuleId] [int] NULL,
	[ModuleCode] [int] NULL,
	[Sequence] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[IsStoreWise] [bit] NULL,
	[ModuleType] [int] NOT NULL,
	[ModuleDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_ModuleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OtpMaster]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtpMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Otp] [nvarchar](max) NULL,
	[Guid] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Attempts] [int] NULL,
 CONSTRAINT [PK_OtpMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[DENYPERMISSION] [tinyint] NOT NULL,
	[GRANTPERMISSION] [tinyint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LEVELKEY] [int] NULL,
	[LEVELTABLE] [nvarchar](max) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[OBJECTINTEGERKEY] [int] NULL,
	[OBJECTSTRINGKEY] [nvarchar](max) NULL,
	[OBJECTTABLE] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyCertification]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyCertification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidUntil] [datetime2](7) NOT NULL,
	[IssuedBy] [nvarchar](150) NULL,
	[CertificationNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_PropertyCertification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyFlat]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyFlat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlatNumber] [int] NOT NULL,
	[TotalRooms] [int] NOT NULL,
	[TotalWashrooms] [int] NULL,
	[TotalBalcony] [int] NULL,
	[SuperArea] [int] NOT NULL,
	[Cost] [int] NOT NULL,
	[CarpetArea] [int] NULL,
	[AreaMeasurementUnit] [int] NULL,
	[IsStudyRoomIncluded] [bit] NOT NULL,
	[IsStoreRoomIncluded] [bit] NOT NULL,
	[AppointmentId] [int] NULL,
	[FloorId] [int] NULL,
 CONSTRAINT [PK_PropertyFlat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyImage]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NOT NULL,
	[PropertyId] [int] NULL,
 CONSTRAINT [PK_PropertyImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyMaster]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[PropertyName] [nvarchar](250) NOT NULL,
	[PropertyId] [int] NULL,
	[AreaSize] [int] NOT NULL,
	[ConstructionStatus] [int] NOT NULL,
 CONSTRAINT [PK_PropertyMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyRoomDetail]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyRoomDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[RoomType] [int] NOT NULL,
	[ImageId] [int] NULL,
	[RoomLengthSize] [int] NULL,
	[RoomWidthSize] [int] NULL,
	[RoomHeightSize] [int] NULL,
	[TotalSize] [int] NOT NULL,
	[IsAttachedWashRoom] [bit] NOT NULL,
	[IsFurnished] [bit] NOT NULL,
	[IsAttachedBalcony] [bit] NOT NULL,
	[FlatId] [int] NULL,
 CONSTRAINT [PK_PropertyRoomDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTower]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTower](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[TowerName] [nvarchar](150) NOT NULL,
	[TowerNumber] [int] NOT NULL,
	[ConstructionStatus] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Floors] [int] NOT NULL,
	[PropertyId] [int] NULL,
 CONSTRAINT [PK_PropertyTower] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTowerFloor]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTowerFloor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[FloorName] [nvarchar](50) NULL,
	[FloorNumber] [int] NOT NULL,
	[TotalFlats] [int] NOT NULL,
	[TowerId] [int] NOT NULL,
	[IsRoof] [bit] NOT NULL,
	[IsGroundFloor] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyTowerFloor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyType]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyType](
	[PropertyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Direction] [nvarchar](50) NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 1/20/2021 6:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[Status] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[RoleDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleModule]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[IsMandatory] [bit] NOT NULL,
	[ModuleMasterId] [int] NULL,
	[RoleMasterId] [int] NULL,
 CONSTRAINT [PK_RoleModule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RowAccess]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RowAccess](
	[ACCESSNAME] [nvarchar](450) NOT NULL,
	[ACCESSDESC] [nvarchar](max) NULL,
 CONSTRAINT [PK_RowAccess] PRIMARY KEY CLUSTERED 
(
	[ACCESSNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesInquiry]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesInquiry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[InquirySource] [nvarchar](100) NULL,
	[InquirySourceId] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[InquiryDate] [datetime2](7) NOT NULL,
	[UserId] [int] NULL,
	[CustomerId] [int] NULL,
	[SaleStatus] [int] NOT NULL,
	[PropertyId] [int] NULL,
 CONSTRAINT [PK_SalesInquiry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SettingDefinition]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingDefinition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[NameTid] [int] NULL,
	[DescriptionTid] [int] NULL,
 CONSTRAINT [PK_SettingDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[COUNTRYCODE] [nvarchar](max) NULL,
	[STATE] [nvarchar](max) NULL,
	[STATENAME] [nvarchar](max) NULL,
	[STATENAME_TID] [int] NULL,
	[CountryId] [nvarchar](3) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SystemSettings]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CompanyId] [int] NOT NULL,
	[LogoutTime] [int] NOT NULL,
	[LoginFailedAttempt] [int] NOT NULL,
	[MaxLeaveMarkDays] [int] NOT NULL,
	[WeeklyOffDays] [nvarchar](max) NULL,
	[IdleSystemDay] [int] NOT NULL,
 CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableCode]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableCode](
	[TABLECODE] [int] NOT NULL,
	[TABLETYPE] [smallint] NOT NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[DESCRIPTION_TID] [int] NULL,
	[USERCODE] [nvarchar](max) NULL,
 CONSTRAINT [PK_TableCode] PRIMARY KEY CLUSTERED 
(
	[TABLECODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableType]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableType](
	[TABLETYPE] [smallint] NOT NULL,
	[TABLENAME] [nvarchar](max) NULL,
	[DATABASETABLE] [nvarchar](max) NULL,
	[TABLENAME_TID] [int] NULL,
 CONSTRAINT [PK_TableType] PRIMARY KEY CLUSTERED 
(
	[TABLETYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TASK]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TASK](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[TASKNAME] [nvarchar](max) NULL,
	[TASKNAME_TID] [int] NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[DESCRIPTION_TID] [int] NULL,
 CONSTRAINT [PK_TASK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaxRate]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxRate](
	[TAXCODE] [nvarchar](450) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[DESCRIPTION_TID] [int] NULL,
 CONSTRAINT [PK_TaxRate] PRIMARY KEY CLUSTERED 
(
	[TAXCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UploadedDocument]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadedDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Document] [nvarchar](max) NULL,
	[FileType] [int] NOT NULL,
	[DocumentType] [int] NOT NULL,
	[DocumentStatus] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[LocationUrl] [nvarchar](1000) NULL,
 CONSTRAINT [PK_UploadedDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[AccountStatus] [int] NULL,
	[IsActive] [bit] NULL,
	[SeniorEmpId] [int] NULL,
	[IsEmployee] [bit] NULL,
	[Phone] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[CompanyId] [int] NULL,
	[UserType] [int] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoleModulePermission]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleModulePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[RoleModuleId] [int] NULL,
	[UserId] [int] NULL,
	[ModuleId] [int] NULL,
	[PermissionId] [int] NOT NULL,
	[PermissionValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserRoleModulePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSettings]    Script Date: 1/20/2021 6:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[UserId] [int] NULL,
	[COLCHARACTER] [nvarchar](max) NULL,
	[COLINTEGER] [int] NULL,
	[COLBOOLEAN] [bit] NULL,
	[COLDECIMAL] [decimal](18, 2) NULL,
	[SettingId] [int] NULL,
 CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_AddressMaster_BuilderMasterId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AddressMaster_BuilderMasterId] ON [dbo].[AddressMaster]
(
	[BuilderMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AddressMaster_CustomerId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AddressMaster_CustomerId] ON [dbo].[AddressMaster]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AddressMaster_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_AddressMaster_UserId] ON [dbo].[AddressMaster]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointment_AppointmentId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_AppointmentId] ON [dbo].[Appointment]
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointment_CustomerId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_CustomerId] ON [dbo].[Appointment]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointment_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_UserId] ON [dbo].[Appointment]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuilderProperties_BuilderId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_BuilderProperties_BuilderId] ON [dbo].[BuilderProperties]
(
	[BuilderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuilderProperties_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_BuilderProperties_PropertyId] ON [dbo].[BuilderProperties]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Country_ADDRESSSTYLE]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Country_ADDRESSSTYLE] ON [dbo].[Country]
(
	[ADDRESSSTYLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Country_DEFAULTCURRENCY]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Country_DEFAULTCURRENCY] ON [dbo].[Country]
(
	[DEFAULTCURRENCY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Country_DEFAULTTAXCODE]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Country_DEFAULTTAXCODE] ON [dbo].[Country]
(
	[DEFAULTTAXCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Country_NAMESTYLE]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Country_NAMESTYLE] ON [dbo].[Country]
(
	[NAMESTYLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Country_POSTCODESEARCHCODE]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Country_POSTCODESEARCHCODE] ON [dbo].[Country]
(
	[POSTCODESEARCHCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DailyLoginHistory_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_DailyLoginHistory_UserId] ON [dbo].[DailyLoginHistory]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmailMergeFields_EmailTemplateId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmailMergeFields_EmailTemplateId] ON [dbo].[EmailMergeFields]
(
	[EmailTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LoginAttemptHistory_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_LoginAttemptHistory_UserId] ON [dbo].[LoginAttemptHistory]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyCertification_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyCertification_PropertyId] ON [dbo].[PropertyCertification]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyFlat_AppointmentId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyFlat_AppointmentId] ON [dbo].[PropertyFlat]
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyFlat_FloorId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyFlat_FloorId] ON [dbo].[PropertyFlat]
(
	[FloorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyImage_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyImage_PropertyId] ON [dbo].[PropertyImage]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyMaster_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyMaster_PropertyId] ON [dbo].[PropertyMaster]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyRoomDetail_FlatId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyRoomDetail_FlatId] ON [dbo].[PropertyRoomDetail]
(
	[FlatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyTower_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyTower_PropertyId] ON [dbo].[PropertyTower]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PropertyTowerFloor_TowerId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyTowerFloor_TowerId] ON [dbo].[PropertyTowerFloor]
(
	[TowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleModule_ModuleMasterId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleModule_ModuleMasterId] ON [dbo].[RoleModule]
(
	[ModuleMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleModule_RoleMasterId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleModule_RoleMasterId] ON [dbo].[RoleModule]
(
	[RoleMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInquiry_CustomerId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInquiry_CustomerId] ON [dbo].[SalesInquiry]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInquiry_PropertyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInquiry_PropertyId] ON [dbo].[SalesInquiry]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesInquiry_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SalesInquiry_UserId] ON [dbo].[SalesInquiry]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_State_CountryId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_State_CountryId] ON [dbo].[State]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SystemSettings_CompanyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SystemSettings_CompanyId] ON [dbo].[SystemSettings]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableCode_TABLETYPE]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_TableCode_TABLETYPE] ON [dbo].[TableCode]
(
	[TABLETYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UploadedDocument_CustomerId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UploadedDocument_CustomerId] ON [dbo].[UploadedDocument]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserMaster_CompanyId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserMaster_CompanyId] ON [dbo].[UserMaster]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoleModulePermission_RoleModuleId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoleModulePermission_RoleModuleId] ON [dbo].[UserRoleModulePermission]
(
	[RoleModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserSettings_SettingId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserSettings_SettingId] ON [dbo].[UserSettings]
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserSettings_UserId]    Script Date: 1/20/2021 6:28:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserSettings_UserId] ON [dbo].[UserSettings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [AccountStatus]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [ReferenceSource]
GO
ALTER TABLE [dbo].[Permissions] ADD  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Permissions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Permissions] ADD  DEFAULT (CONVERT([tinyint],(0))) FOR [DENYPERMISSION]
GO
ALTER TABLE [dbo].[Permissions] ADD  DEFAULT (CONVERT([tinyint],(0))) FOR [GRANTPERMISSION]
GO
ALTER TABLE [dbo].[Permissions] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PropertyMaster] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PropertyTower] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SalesInquiry] ADD  DEFAULT ((2)) FOR [SaleStatus]
GO
ALTER TABLE [dbo].[UploadedDocument] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UploadedDocument] ADD  DEFAULT ((2)) FOR [DocumentType]
GO
ALTER TABLE [dbo].[UploadedDocument] ADD  DEFAULT ((1)) FOR [DocumentStatus]
GO
ALTER TABLE [dbo].[AddressMaster]  WITH CHECK ADD  CONSTRAINT [FK_AddressMaster_BuilderMaster_BuilderMasterId] FOREIGN KEY([BuilderMasterId])
REFERENCES [dbo].[BuilderMaster] ([Id])
GO
ALTER TABLE [dbo].[AddressMaster] CHECK CONSTRAINT [FK_AddressMaster_BuilderMaster_BuilderMasterId]
GO
ALTER TABLE [dbo].[AddressMaster]  WITH CHECK ADD  CONSTRAINT [FK_AddressMaster_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[AddressMaster] CHECK CONSTRAINT [FK_AddressMaster_Customer_CustomerId]
GO
ALTER TABLE [dbo].[AddressMaster]  WITH CHECK ADD  CONSTRAINT [FK_AddressMaster_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[AddressMaster] CHECK CONSTRAINT [FK_AddressMaster_UserMaster_UserId]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Customer_CustomerId]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_SalesInquiry_AppointmentId] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[SalesInquiry] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_SalesInquiry_AppointmentId]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_UserMaster_UserId]
GO
ALTER TABLE [dbo].[BuilderProperties]  WITH CHECK ADD  CONSTRAINT [FK_BuilderProperties_BuilderMaster_BuilderId] FOREIGN KEY([BuilderId])
REFERENCES [dbo].[BuilderMaster] ([Id])
GO
ALTER TABLE [dbo].[BuilderProperties] CHECK CONSTRAINT [FK_BuilderProperties_BuilderMaster_BuilderId]
GO
ALTER TABLE [dbo].[BuilderProperties]  WITH CHECK ADD  CONSTRAINT [FK_BuilderProperties_PropertyMaster_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyMaster] ([Id])
GO
ALTER TABLE [dbo].[BuilderProperties] CHECK CONSTRAINT [FK_BuilderProperties_PropertyMaster_PropertyId]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Currency_DEFAULTCURRENCY] FOREIGN KEY([DEFAULTCURRENCY])
REFERENCES [dbo].[Currency] ([CURRENCY])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Currency_DEFAULTCURRENCY]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_TableCode_ADDRESSSTYLE] FOREIGN KEY([ADDRESSSTYLE])
REFERENCES [dbo].[TableCode] ([TABLECODE])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_TableCode_ADDRESSSTYLE]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_TableCode_NAMESTYLE] FOREIGN KEY([NAMESTYLE])
REFERENCES [dbo].[TableCode] ([TABLECODE])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_TableCode_NAMESTYLE]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_TableCode_POSTCODESEARCHCODE] FOREIGN KEY([POSTCODESEARCHCODE])
REFERENCES [dbo].[TableCode] ([TABLECODE])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_TableCode_POSTCODESEARCHCODE]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_TaxRate_DEFAULTTAXCODE] FOREIGN KEY([DEFAULTTAXCODE])
REFERENCES [dbo].[TaxRate] ([TAXCODE])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_TaxRate_DEFAULTTAXCODE]
GO
ALTER TABLE [dbo].[DailyLoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_DailyLoginHistory_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[DailyLoginHistory] CHECK CONSTRAINT [FK_DailyLoginHistory_UserMaster_UserId]
GO
ALTER TABLE [dbo].[EmailMergeFields]  WITH CHECK ADD  CONSTRAINT [FK_EmailMergeFields_EmailTemplate_EmailTemplateId] FOREIGN KEY([EmailTemplateId])
REFERENCES [dbo].[EmailTemplate] ([Id])
GO
ALTER TABLE [dbo].[EmailMergeFields] CHECK CONSTRAINT [FK_EmailMergeFields_EmailTemplate_EmailTemplateId]
GO
ALTER TABLE [dbo].[LoginAttemptHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginAttemptHistory_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginAttemptHistory] CHECK CONSTRAINT [FK_LoginAttemptHistory_UserMaster_UserId]
GO
ALTER TABLE [dbo].[PropertyCertification]  WITH CHECK ADD  CONSTRAINT [FK_PropertyCertification_PropertyMaster_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyCertification] CHECK CONSTRAINT [FK_PropertyCertification_PropertyMaster_PropertyId]
GO
ALTER TABLE [dbo].[PropertyFlat]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFlat_PropertyTowerFloor_FloorId] FOREIGN KEY([FloorId])
REFERENCES [dbo].[PropertyTowerFloor] ([Id])
GO
ALTER TABLE [dbo].[PropertyFlat] CHECK CONSTRAINT [FK_PropertyFlat_PropertyTowerFloor_FloorId]
GO
ALTER TABLE [dbo].[PropertyFlat]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFlat_SalesInquiry_AppointmentId] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[SalesInquiry] ([Id])
GO
ALTER TABLE [dbo].[PropertyFlat] CHECK CONSTRAINT [FK_PropertyFlat_SalesInquiry_AppointmentId]
GO
ALTER TABLE [dbo].[PropertyImage]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImage_PropertyMaster_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyMaster] ([Id])
GO
ALTER TABLE [dbo].[PropertyImage] CHECK CONSTRAINT [FK_PropertyImage_PropertyMaster_PropertyId]
GO
ALTER TABLE [dbo].[PropertyMaster]  WITH CHECK ADD  CONSTRAINT [FK_PropertyMaster_PropertyType_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyType] ([PropertyTypeId])
GO
ALTER TABLE [dbo].[PropertyMaster] CHECK CONSTRAINT [FK_PropertyMaster_PropertyType_PropertyId]
GO
ALTER TABLE [dbo].[PropertyRoomDetail]  WITH CHECK ADD  CONSTRAINT [FK_PropertyRoomDetail_PropertyFlat_FlatId] FOREIGN KEY([FlatId])
REFERENCES [dbo].[PropertyFlat] ([Id])
GO
ALTER TABLE [dbo].[PropertyRoomDetail] CHECK CONSTRAINT [FK_PropertyRoomDetail_PropertyFlat_FlatId]
GO
ALTER TABLE [dbo].[PropertyTower]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTower_PropertyMaster_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyMaster] ([Id])
GO
ALTER TABLE [dbo].[PropertyTower] CHECK CONSTRAINT [FK_PropertyTower_PropertyMaster_PropertyId]
GO
ALTER TABLE [dbo].[PropertyTowerFloor]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTowerFloor_PropertyTower_TowerId] FOREIGN KEY([TowerId])
REFERENCES [dbo].[PropertyTower] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyTowerFloor] CHECK CONSTRAINT [FK_PropertyTowerFloor_PropertyTower_TowerId]
GO
ALTER TABLE [dbo].[RoleModule]  WITH CHECK ADD  CONSTRAINT [FK_RoleModule_ModuleMaster_ModuleMasterId] FOREIGN KEY([ModuleMasterId])
REFERENCES [dbo].[ModuleMaster] ([Id])
GO
ALTER TABLE [dbo].[RoleModule] CHECK CONSTRAINT [FK_RoleModule_ModuleMaster_ModuleMasterId]
GO
ALTER TABLE [dbo].[RoleModule]  WITH CHECK ADD  CONSTRAINT [FK_RoleModule_RoleMaster_RoleMasterId] FOREIGN KEY([RoleMasterId])
REFERENCES [dbo].[RoleMaster] ([Id])
GO
ALTER TABLE [dbo].[RoleModule] CHECK CONSTRAINT [FK_RoleModule_RoleMaster_RoleMasterId]
GO
ALTER TABLE [dbo].[SalesInquiry]  WITH CHECK ADD  CONSTRAINT [FK_SalesInquiry_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[SalesInquiry] CHECK CONSTRAINT [FK_SalesInquiry_Customer_CustomerId]
GO
ALTER TABLE [dbo].[SalesInquiry]  WITH CHECK ADD  CONSTRAINT [FK_SalesInquiry_PropertyMaster_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[PropertyMaster] ([Id])
GO
ALTER TABLE [dbo].[SalesInquiry] CHECK CONSTRAINT [FK_SalesInquiry_PropertyMaster_PropertyId]
GO
ALTER TABLE [dbo].[SalesInquiry]  WITH CHECK ADD  CONSTRAINT [FK_SalesInquiry_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[SalesInquiry] CHECK CONSTRAINT [FK_SalesInquiry_UserMaster_UserId]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([COUNTRYCODE])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country_CountryId]
GO
ALTER TABLE [dbo].[SystemSettings]  WITH CHECK ADD  CONSTRAINT [FK_SystemSettings_CompanyMaster_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CompanyMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemSettings] CHECK CONSTRAINT [FK_SystemSettings_CompanyMaster_CompanyId]
GO
ALTER TABLE [dbo].[TableCode]  WITH CHECK ADD  CONSTRAINT [FK_TableCode_TableType_TABLETYPE] FOREIGN KEY([TABLETYPE])
REFERENCES [dbo].[TableType] ([TABLETYPE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TableCode] CHECK CONSTRAINT [FK_TableCode_TableType_TABLETYPE]
GO
ALTER TABLE [dbo].[UploadedDocument]  WITH CHECK ADD  CONSTRAINT [FK_UploadedDocument_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[UploadedDocument] CHECK CONSTRAINT [FK_UploadedDocument_Customer_CustomerId]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_CompanyMaster_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CompanyMaster] ([Id])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_CompanyMaster_CompanyId]
GO
ALTER TABLE [dbo].[UserRoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleModulePermission_RoleModule_RoleModuleId] FOREIGN KEY([RoleModuleId])
REFERENCES [dbo].[RoleModule] ([Id])
GO
ALTER TABLE [dbo].[UserRoleModulePermission] CHECK CONSTRAINT [FK_UserRoleModulePermission_RoleModule_RoleModuleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_RoleMaster_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_RoleMaster_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_UserMaster_UserId]
GO
ALTER TABLE [dbo].[UserSettings]  WITH CHECK ADD  CONSTRAINT [FK_UserSettings_SettingDefinition_SettingId] FOREIGN KEY([SettingId])
REFERENCES [dbo].[SettingDefinition] ([Id])
GO
ALTER TABLE [dbo].[UserSettings] CHECK CONSTRAINT [FK_UserSettings_SettingDefinition_SettingId]
GO
ALTER TABLE [dbo].[UserSettings]  WITH CHECK ADD  CONSTRAINT [FK_UserSettings_UserMaster_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[UserSettings] CHECK CONSTRAINT [FK_UserSettings_UserMaster_UserId]
GO
USE [master]
GO
ALTER DATABASE [CRMDb] SET  READ_WRITE 
GO
