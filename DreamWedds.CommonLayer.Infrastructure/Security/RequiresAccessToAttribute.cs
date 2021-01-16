using System;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequiresAccessToAttribute : Attribute
    {
        public RequiresAccessToAttribute(
            ApplicationTask task,
            ApplicationTaskAccessLevel level = ApplicationTaskAccessLevel.Execute)
        {
            Task = task;
            Level = level;
        }

        public ApplicationTask Task { get; }

        public ApplicationTaskAccessLevel Level { get; }
    }
}
