using DreamWedds.BusinessLayer.Services;
using DreamWedds.CommonLayer.Application.DTO;
using DreamWedds.CommonLayer.Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DreamWedds.CommonLayer.Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IUserService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            int userId = _currentUserService.UserId;
            string user = string.Empty;

            if (userId > 0)
            {
                user = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, user, request);
        }
    }
}
