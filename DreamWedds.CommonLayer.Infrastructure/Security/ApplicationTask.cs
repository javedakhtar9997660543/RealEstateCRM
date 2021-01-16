using System;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    public enum ApplicationTask
    {
        // A task to signify it is allowed access.
        AllowedAccessAlways = -2,

        /// <summary>Required for business entities that are yet to define task security</summary>
        NotDefined = -1,
        /// <summary>Allows to create, update or delete event note types in the system.</summary>
        MaintainUser = 11,
        MaintainCaseAttachments = 231,
        ScheduleEpoDataDownload = 232,
        MaintainLocality = 234,
    }

    [Flags]
    public enum ApplicationTaskAccessLevel
    {
        None = 0x00,
        Modify = 0x01,
        Create = 0x02,
        Delete = 0x04,
        Execute = 0x08
    }
}
