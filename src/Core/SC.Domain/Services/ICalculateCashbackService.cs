using SC.Domain.ValueObjects;

namespace SC.Domain.Services
{
    public interface ICalculateCashbackService
    {
        decimal CalculateAmountCashback(Amount price);
    }
}