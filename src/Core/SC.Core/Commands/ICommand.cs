using MediatR;

namespace SC.Core.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : ICommandResult
    {
    }
}