using SC.Domain.Queries;
using SC.Domain.Commands;
using System.Threading.Tasks;

namespace SC.Bus
{
    public interface IMediatorHandler
    {
        Task<T> Send<T>(ICommand<T> command) where T : ICommandResult;
        Task<T> Execute<T>(IQuery<T> query) where T : IQueryModel;
    }
}