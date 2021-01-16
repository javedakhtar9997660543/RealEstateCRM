using System;
using System.Collections.Generic;
using AdminProject.CommonLayer.Application.Model.Security;

namespace AdminProject.PersistenceLayer.Repository.Security
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
