using SC.Domain.Queries;
using SC.Domain.Commands;
using System.Threading.Tasks;
using MediatR;

namespace SC.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<T> Send<T>(ICommand<T> command) where T : ICommandResult
        {
            return Publish(command);
        }

        public Task<T> Execute<T>(IQuery<T> query) where T : IQueryModel
        {
            return Publish(query);
        }

        private Task<T> Publish<T>(IRequest<T> request)
        {
            return _mediator.Send(request);
        }
    }
}