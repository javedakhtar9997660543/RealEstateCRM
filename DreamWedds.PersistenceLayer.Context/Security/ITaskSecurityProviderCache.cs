using System;
using System.Collections.Generic;
using System.Text;
using DreamWedds.CommonLayer.Application.Model.Security;

namespace DreamWedds.PersistenceLayer.Repository.Security
{
    public interface ITaskSecurityProviderCache : IDisableApplicationCache
    {
        bool IsEmpty { get; }

        void Clear();

        IDictionary<short, ValidSecurityTask> Resolve(Func<int, IDictionary<short, ValidSecurityTask>> valuesFactory, int userIdentityId);
    }

    public interface IDisableApplicationCache
    {
        bool IsDisabled { get; set; }
    }
}
