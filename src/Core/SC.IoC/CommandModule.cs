using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SC.Application.Repository;
using SC.Domain.Commands;
using SC.Infrastructure;

namespace SC.IoC {
    public static class CommandModule {
        public static void RegisterCommand (this IServiceCollection services) {

            services.AddMediatR (typeof (ICommandResult), typeof (ICommandHandler<,>));
            
            services.AddScoped(typeof(IWriteOnlyRepository<>), typeof(WriteDbContext<>));
        }
    }
}