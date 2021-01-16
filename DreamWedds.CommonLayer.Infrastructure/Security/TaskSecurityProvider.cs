using System;
using System.Collections.Generic;
using AutoMapper;
using DreamWedds.CommonLayer.Application.Model.Security;
using DreamWedds.PersistenceLayer.Repository.PersistenceServices;

namespace DreamWedds.CommonLayer.Infrastructure.Security
{
    public class TaskSecurityProvider : ITaskSecurityProvider
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IMapper _mapper;

        public TaskSecurityProvider(ISecurityRepository securityRepository, IMapper mapper)
        {
            _securityRepository = securityRepository;
            _mapper = mapper;
        }

        public IEnumerable<ValidSecurityTask> ListAvailableTasks(int? userId = null)
        {
            return _securityRepository.ListAvailableTasks(userId);
        }

        public bool HasAccessTo(ApplicationTask applicationTask)
        {
            throw new NotImplementedException();
        }

        public bool HasAccessTo(ApplicationTask applicationTask, ApplicationTaskAccessLevel level)
        {
            throw new NotImplementedException();
        }

        public bool UserHasAccessTo(int userId, ApplicationTask applicationTask)
        {
            throw new NotImplementedException();
        }
    }

}
