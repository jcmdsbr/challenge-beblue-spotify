using System;
using SC.Domain.ValueObjects;

namespace SC.Domain.Services
{
    public class CalculateCashback : ICalculateCashbackService
    {
        protected CalculateCashback(decimal fridayPercent, decimal mondayPercent,
            decimal saturdayPercent, decimal sundayPercent, decimal thursdayPercent,
            decimal tuesdayPercent, decimal wednesdayPercent)
        {
            FridayPercent = fridayPercent;
            MondayPercent = mondayPercent;
            SaturdayPercent = saturdayPercent;
            SundayPercent = sundayPercent;
            ThursdayPercent = thursdayPercent;
            TuesdayPercent = tuesdayPercent;
            WednesdayPercent = wednesdayPercent;
        }

        protected decimal FridayPercent { get; }
        protected decimal MondayPercent { get; }
        protected decimal SaturdayPercent { get; }
        protected decimal SundayPercent { get; }
        protected decimal ThursdayPercent { get; }
        protected decimal TuesdayPercent { get; }
        protected decimal WednesdayPercent { get; }

        public decimal CalculateAmountCashback(Amount price)
        {
            var today = DateTime.Now.DayOfWeek;

            switch (today)
            {
                case DayOfWeek.Friday: return price * FridayPercent;
                case DayOfWeek.Monday: return price * MondayPercent;
                case DayOfWeek.Saturday: return price * SaturdayPercent;
                case DayOfWeek.Sunday: return price * SundayPercent;
                case DayOfWeek.Thursday: return price * ThursdayPercent;
                case DayOfWeek.Tuesday: return price * TuesdayPercent;
                case DayOfWeek.Wednesday: return price * WednesdayPercent;
                default: return price;
            }
        }
    }
}