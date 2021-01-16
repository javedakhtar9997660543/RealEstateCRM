using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AdminProject.CommonLayer.Application.Model.Security;

namespace AdminProject.PersistenceLayer.Repository.Security
{
    public class TaskSecurityProviderCache : ITaskSecurityProviderCache
    {
        static bool _isDisable;

        static readonly ConcurrentDictionary<int, IDictionary<short, ValidSecurityTask>> Cache =
            new ConcurrentDictionary<int, IDictionary<short, ValidSecurityTask>>();

        public bool IsEmpty => Cache.IsEmpty;

        public bool IsDisabled
        {
            get => _isDisable;
            set => _isDisable = value;
        }
        public void Clear()
        {
            Cache.Clear();
        }

        public IDictionary<short, ValidSecurityTask> Resolve(Func<int, IDictionary<short, ValidSecurityTask>> valuesFactory, int userIdentityId)
        {
            return IsDisabled
                ? valuesFactory(userIdentityId)
                : Cache.GetOrAdd(userIdentityId, x => valuesFactory(userIdentityId));
        }
    }
}
