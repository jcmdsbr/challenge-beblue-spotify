namespace SC.Domain.Services
{
    public class RockCategoryCashbackService : CalculateCashback
    {
        public RockCategoryCashbackService()
            : base(0.40m, 0.10m, 0.15m, 0.15m, 0.15m, 0.20m, 0.40m)
        {
        }
    }
}