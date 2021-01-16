using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    public class TaskAuthorizationHandler : AuthorizationHandler<TaskPermissionsRequirement>
    {
        readonly ITaskAuthorisation _taskAuthorisation;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskAuthorizationHandler(ITaskAuthorisation taskAuthorisation, IHttpContextAccessor httpContextAccessor)
        {
            _taskAuthorisation = taskAuthorisation ?? throw new ArgumentNullException(nameof(taskAuthorisation));
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TaskPermissionsRequirement requirement)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (!IsUserAuthenticated(context)) throw new UnauthorizedAccessException();

            var attributes = GetAttributes<RequiresAccessToAttribute>(context).ToList();
            var isSuccess = _taskAuthorisation.Authorize(attributes);
            if (!isSuccess)
            {
                throw new Exception("User is not authorized. Forbidden request.");
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        private bool IsUserAuthenticated(AuthorizationHandlerContext context)
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            var routeInfo = context.Resource as RouteEndpoint;
            var response = filterContext?.HttpContext.Response;
            if (!context.User.Identity.IsAuthenticated || string.IsNullOrEmpty(context.User.Identity.Name))
            {
                response?.OnStarting(async () =>
                {
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                });
                return false;
            }

            return true;
        }


        private string GetRouteKey(AuthorizationHandlerContext context)
        {
            var verb = this._httpContextAccessor.HttpContext.Request.Method;
            var routeKey = string.Empty;

            if (context.Resource is Endpoint endpoint)
            {
                var cad = endpoint.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();
                var controllerFullName = cad.ControllerTypeInfo.FullName;
                var actionName = cad.ActionName;
                var bindings = cad.Parameters;
                var actionParams = ".";

                if (bindings.Any())
                {
                    bindings.ToList().ForEach(p => actionParams += p.ParameterType.Name + ".");
                }

                routeKey = $"{controllerFullName}.{actionName}{actionParams}{verb}";
            }

            return routeKey;
        }


        private IEnumerable<TAttribute> GetAttributes<TAttribute>(AuthorizationHandlerContext authContext)
        {
            if (authContext.Resource is RouteEndpoint routeEndpoint)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var actionDescriptor = routeEndpoint.Metadata.OfType<ControllerActionDescriptor>().SingleOrDefault();
                var attributes = actionDescriptor?.MethodInfo.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>();
                return attributes;
            }

            return null;
        }
    }
}
