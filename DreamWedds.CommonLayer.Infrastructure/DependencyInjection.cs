using DreamWedds.BusinessLayer.ServiceManager;
using DreamWedds.CommonLayer.Application.Interfaces;
using DreamWedds.CommonLayer.ApplicationServices;
using DreamWedds.CommonLayer.ApplicationServices.Impl;
using DreamWedds.CommonLayer.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DreamWedds.PersistenceLayer.Repository;
using DreamWedds.PersistenceLayer.Repository.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DreamWedds.CommonLayer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdminDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddRepositoryDependency();
            services.AddTransient<ITokenClaimsService, IdentityTokenClaimService>();
            services.AddScoped<ITaskAuthorisation, TaskAuthorisation>();
            services.AddScoped<ITaskSecurityProvider, TaskSecurityProvider>();
            services.AddScoped<IAuthorizationHandler, TaskAuthorizationHandler>();

            services.AddScoped<IUserService, UserServiceManager>();
            services.AddScoped<ISecurityService, SecurityServiceManager>();
            services.AddScoped<IEmailService, EmailServiceManager>();
           
            return services;
        }
    }
}
