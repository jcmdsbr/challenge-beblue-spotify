using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.Application.Repository;
using SC.Bus;
using SC.Infrastructure;

namespace SC.IoC
{
    public static class InfrastructureModule
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = typeof(SCContext).Namespace;
            var dbConnectionString = configuration.GetConnectionString("SqlConnection");

            services.AddDbContext<SCContext>(options =>
                options.UseSqlServer(dbConnectionString,
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(assemblyName)
                )
            );
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}