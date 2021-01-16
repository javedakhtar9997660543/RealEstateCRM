using System.Collections.Generic;

namespace AdminProject.CommonLayer.Infrastructure.Security
{
    public interface ITaskAuthorisation
    {
        bool Authorize(IEnumerable<RequiresAccessToAttribute> actionAttributes);
    }
}
