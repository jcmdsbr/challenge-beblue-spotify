using System.Threading.Tasks;
using SC.Domain.Commands;
using SC.Domain.Queries;

namespace SC.Bus
{
    public interface IMediatorHandler
    {
        Task<T> Send<T>(ICommand<T> command) where T : ICommandResult;
        Task<T> Execute<T>(IQuery<T> query) where T : IQueryModel;
    }
}