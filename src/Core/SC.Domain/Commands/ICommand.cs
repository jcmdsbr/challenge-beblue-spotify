using MediatR;

namespace SC.Domain.Commands
{
   public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : ICommandResult
    {
    }
}