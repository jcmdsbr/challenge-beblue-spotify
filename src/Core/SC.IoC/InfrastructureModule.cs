using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.Application.Repositories;
using SC.Bus;
using SC.Core.Repository;
using SC.Infrastructure;
using SC.Infrastructure.Repositories;

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

            services.AddScoped<ICategoryWriteOnlyRepository, CategoryWriteOnlyRepository>();
            services.AddScoped<IPlaylistWriteOnlyRepository, PlaylistWriteOnlyRepository>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IWriteOnlyRepository<>), typeof(WriteDbContext<>));
            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadDbContext<>));
        }
    }
}