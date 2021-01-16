using AdminProject.PersistenceLayer.Repository.Impl;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using AdminProject.PersistenceLayer.Repository.Repository;
using AdminProject.PersistenceLayer.Repository.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AdminProject.PersistenceLayer.Repository
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserDataImpl>();
            services.AddScoped<IEmailRepository, EmailDataImpl>();
            services.AddScoped<ISecurityRepository, SecurityDataImpl>();
            services.AddScoped<ITaskSecurityProviderCache, TaskSecurityProviderCache>();
        }
    }
}
