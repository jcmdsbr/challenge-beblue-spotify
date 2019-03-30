using MediatR;

namespace SC.Domain.Queries
{
     public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : IQueryModel
    {
    }
}