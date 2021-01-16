using AdminProject.BusinessLayer.ServiceManager;
using AdminProject.CommonLayer.Application.Interfaces;
using AdminProject.CommonLayer.ApplicationServices;
using AdminProject.CommonLayer.ApplicationServices.Impl;
using AdminProject.CommonLayer.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdminProject.PersistenceLayer.Repository;
using AdminProject.PersistenceLayer.Repository.Repository;
using Microsoft.AspNetCore.Authorization;

namespace AdminProject.CommonLayer.Infrastructure
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
