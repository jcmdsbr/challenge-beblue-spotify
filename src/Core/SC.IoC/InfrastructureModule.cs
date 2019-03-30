using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.Infrastructure;

namespace SC.IoC {
    public static class InfrastructureModule {
        public static void RegisterDatabase (this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<SCContext> (options =>
                options.UseSqlServer (configuration.GetConnectionString ("SqlConnection")));
        }
    }
}