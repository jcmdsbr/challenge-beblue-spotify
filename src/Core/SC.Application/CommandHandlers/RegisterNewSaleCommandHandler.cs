using System.Threading;
using System.Threading.Tasks;
using SC.Domain.Commands;
using SC.Domain.Commands.RegisterNewSale;

namespace SC.Application.CommandHandlers
{
    public class RegisterNewSaleCommandHandler : ICommandHandler<RegisterNewSaleCommand, RegisterNewSaleCommandResult>
    {
        public Task<RegisterNewSaleCommandResult> Handle(RegisterNewSaleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}