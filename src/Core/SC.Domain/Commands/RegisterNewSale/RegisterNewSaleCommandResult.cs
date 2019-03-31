using SC.Core.Commands;

namespace SC.Domain.Commands.RegisterNewSale
{
    public class RegisterNewSaleCommandResult : CommandResult
    {
        public RegisterNewSaleCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public RegisterNewSaleCommandResult(string message) : this(true, message)
        {

        }

        public string Message { get; }
    }
}