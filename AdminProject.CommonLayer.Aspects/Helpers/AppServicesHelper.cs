using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;

namespace AdminProject.CommonLayer.Aspects.Helpers
{
    public static class AppServicesHelper
    {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static HttpContext HttpContext_Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        public static IHostingEnvironment HostingEnvironment
        {
            get
            {
                return services.GetService(typeof(IHostingEnvironment)) as IHostingEnvironment;
            }
        }

        /// <summary>
        /// Configuration settings from appsetting.json.
        /// </summary>
        public static Encryption Config
        {
            get
            {
                //This works to get file changes.
                var s = services.GetService(typeof(IOptionsMonitor<Encryption>)) as IOptionsMonitor<Encryption>;
                Encryption config = s.CurrentValue;

                return config;
            }
        }
    }
    public class Encryption
    {
        public string EncryptionDictionary { get; set; }
    }
}

