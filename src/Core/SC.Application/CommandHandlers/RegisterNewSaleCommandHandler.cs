
using SC.Domain.Commands;
using SC.Domain.Commands.RegisterNewSale;
using System.Threading;
using System.Threading.Tasks;
using SC.Core.Commands;

namespace SC.Application.CommandHandlers
{
    public class RegisterNewSaleCommandHandler : ICommandHandler<RegisterNewSaleCommand, RegisterNewSaleCommandResult>
    {
        
        public async Task<RegisterNewSaleCommandResult> Handle(RegisterNewSaleCommand request,
            CancellationToken cancellationToken)
        {



            return await Task.FromResult(new RegisterNewSaleCommandResult(true, "Sucesso"));
        }
    }
}