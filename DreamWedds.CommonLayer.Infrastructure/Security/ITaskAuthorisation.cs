
using System.Collections;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    public interface ITaskAuthorisation
    {
        bool Authorize(IEnumerable<RequiresAccessToAttribute> actionAttributes);
    }
}
