using System;
using System.Collections.Generic;
using System.Linq;
using DreamWedds.CommonLayer.Application.Model.Security;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    public class TaskAuthorisation : ITaskAuthorisation
    {
        readonly ITaskSecurityProvider _taskSecurityProvider;

        public TaskAuthorisation(ITaskSecurityProvider taskSecurityProvider)
        {
            _taskSecurityProvider = taskSecurityProvider;
        }

        public bool Authorize(IEnumerable<RequiresAccessToAttribute> actionAttributes)
        {
            if (actionAttributes == null) throw new ArgumentNullException(nameof(actionAttributes));
            //if(controllerAttributes == null) throw new ArgumentNullException(nameof(controllerAttributes));

            var actionAttributesArray = actionAttributes.ToArray();
            //var controllerAttributesArray = controllerAttributes.ToArray();

            if (!actionAttributesArray.Any())
                return true;

            var allowedTasks = _taskSecurityProvider.ListAvailableTasks();

            if (actionAttributesArray.Any(a => allowedTasks.Any(t => t.TaskId == (int)a.Task && HasAccess(t, a))))
                return true;

            return false;
        }

        static bool HasAccess(ValidSecurityTask task, RequiresAccessToAttribute attribute)
        {
            var hasAccess = true;

            hasAccess &= (attribute.Level & ApplicationTaskAccessLevel.Create) != ApplicationTaskAccessLevel.Create ||
                         task.CanInsert;
            hasAccess &= (attribute.Level & ApplicationTaskAccessLevel.Modify) != ApplicationTaskAccessLevel.Modify ||
                         task.CanUpdate;
            hasAccess &= (attribute.Level & ApplicationTaskAccessLevel.Delete) != ApplicationTaskAccessLevel.Delete ||
                         task.CanDelete;
            hasAccess &= (attribute.Level & ApplicationTaskAccessLevel.Execute) != ApplicationTaskAccessLevel.Execute ||
                         task.CanExecute;

            return hasAccess;
        }

    }
}
