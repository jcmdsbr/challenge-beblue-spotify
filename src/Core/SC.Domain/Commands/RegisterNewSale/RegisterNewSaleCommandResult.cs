namespace SC.Domain.Commands.RegisterNewSale
{
    public class RegisterNewSaleCommandResult : CommandResult
    {
        public RegisterNewSaleCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public string Message { get; }
    }
}