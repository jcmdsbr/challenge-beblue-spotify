using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SC.IoC
{
    public static class ApplicationModule
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("SC.Application");

            services.AddMediatR(assembly);
        }
    }
}