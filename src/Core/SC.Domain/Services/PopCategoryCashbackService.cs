namespace SC.Domain.Services
{
    public class PopCategoryCashbackService : CalculateCashback
    {
        public PopCategoryCashbackService()
            : base(0.25m, 0.07m, 0.06m, 0.02m, 0.10m, 0.15m, 0.20m)
        {
        }
    }
}