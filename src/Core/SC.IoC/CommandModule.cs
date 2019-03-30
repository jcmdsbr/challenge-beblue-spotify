using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SC.Domain.Commands;

namespace SC.IoC {
    public static class CommandModule {
        public static void RegisterCommand (this IServiceCollection services) {
            services.AddMediatR (typeof (ICommandResult), typeof (ICommandHandler<,>));
        }
    }
}