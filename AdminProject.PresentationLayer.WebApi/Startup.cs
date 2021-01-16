using System.Text;
using System.Threading.Tasks;
using AdminProject.PresentationLayer.WebApi.CustomFilters;
using AdminProject.PresentationLayer.WebApi.Helpers;
using AdminProject.BusinessLayer.Services;
using AdminProject.CommonLayer.Application;
using AdminProject.CommonLayer.Application.AppSettings;
using AdminProject.CommonLayer.Aspects.Helpers;
using AdminProject.CommonLayer.Infrastructure;
using AdminProject.CommonLayer.Infrastructure.Correlation;
using AdminProject.CommonLayer.Infrastructure.Security;
using AdminProject.PresentationLayer.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdminProject.PresentationLayer.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Add Application  CORS

            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            #endregion

            services.Configure<SmtpSettings>(Configuration.GetSection(nameof(SmtpSettings)));
            services.Configure<AccountSettings>(Configuration.GetSection(nameof(AccountSettings)));
            services.Configure<Encryption>(Configuration.GetSection(nameof(Encryption)));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptionsMonitor<Encryption>>().CurrentValue);
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("TaskSecurity", policy =>
                    policy.RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .AddRequirements(new TaskPermissionsRequirement()));
            });


            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var isAuthenticated = context.Principal.Identity.IsAuthenticated;
                            if (!isAuthenticated) context.Fail("Unauthorized");
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ITaskAuthorisation, TaskAuthorisation>();
            //services.AddControllersWithViews(options =>
            //    options.Filters.Add(new AuthorizationAttribute()));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCorrelationId();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}