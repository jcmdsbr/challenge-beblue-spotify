using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SC.Application.Repository;
using SC.Domain.Queries;
using SC.Infrastructure;

namespace SC.IoC
{
    public static class QueryModule
    {
        public static void RegisterQuery(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IQueryModel), typeof(IQueryHandler<,>));

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadDbContext<>));
        }
    }
}