using System;
using System.Collections.Generic;
using System.Text;

namespace DreamWedds.CommonLayer.Application.Model.Security
{
    public class ValidSecurityTask
    {
        public ValidSecurityTask()
        {
        }

        public ValidSecurityTask(short taskId, bool canInsert, bool canUpdate, bool canDelete, bool canExecute)
        {
            TaskId = taskId;
            CanInsert = canInsert;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
            CanExecute = canExecute;
        }

        public short TaskId { get; set; }

        public bool CanInsert { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanExecute { get; set; }
    }
}
