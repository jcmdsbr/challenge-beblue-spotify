namespace SC.Domain.Services
{
    public class MpbCategoryCashbackService : CalculateCashback
    {
        public MpbCategoryCashbackService()
            : base(0.30m, 0.05m, 0.10m, 0.15m, 0.20m, 0.25m, 0.30m)
        {
        }
    }
}