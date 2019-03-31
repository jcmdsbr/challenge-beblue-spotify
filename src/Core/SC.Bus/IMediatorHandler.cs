using System.Threading.Tasks;
using SC.Core.Commands;
using SC.Core.Queries;
using SC.Domain.Commands;

namespace SC.Bus
{
    public interface IMediatorHandler
    {
        Task<T> Send<T>(ICommand<T> command) where T : ICommandResult;
        Task<T> Execute<T>(IQuery<T> query) where T : IQueryModel;
    }
}