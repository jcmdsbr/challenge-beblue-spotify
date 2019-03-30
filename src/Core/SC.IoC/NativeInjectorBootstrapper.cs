using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SC.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterModules(this IServiceCollection services, IConfiguration configuration) 
        {
            services.RegisterDatabase(configuration);
        }
    }
}
