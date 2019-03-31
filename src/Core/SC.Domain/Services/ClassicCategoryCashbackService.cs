namespace SC.Domain.Services
{
    public class ClassicCategoryCashbackService : CalculateCashback
    {
        public ClassicCategoryCashbackService()
            : base(0.35m, 0.03m, 0.05m, 0.08m, 0.13m, 0.18m, 0.25m)
        {
        }
    }
}