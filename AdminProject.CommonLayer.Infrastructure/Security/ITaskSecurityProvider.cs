﻿using System.Collections.Generic;
using AdminProject.CommonLayer.Application.Model.Security;

namespace AdminProject.CommonLayer.Infrastructure.Security
{
    public interface ITaskSecurityProvider
    {
        IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null);

        bool HasAccessTo(ApplicationTask applicationTask);

        bool HasAccessTo(ApplicationTask applicationTask, ApplicationTaskAccessLevel level);

        bool UserHasAccessTo(int userId, ApplicationTask applicationTask);
    }

    public interface ISessionValidator
    {
        bool IsSessionValid(long logId);
    }

}
