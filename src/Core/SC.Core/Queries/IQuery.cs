using MediatR;

namespace SC.Core.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
        where TResult : IQueryModel
    {
    }
}