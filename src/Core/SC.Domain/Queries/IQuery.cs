using MediatR;

namespace SC.Domain.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
        where TResult : IQueryModel
    {
    }
}