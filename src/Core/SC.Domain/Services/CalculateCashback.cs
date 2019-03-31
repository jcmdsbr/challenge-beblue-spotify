using System;
using SC.Domain.ValueObjects;

namespace SC.Domain.Services
{
    public abstract class CalculateCashback : ICalculateCashbackService
    {
        public CalculateCashback(decimal sundayPercent, decimal mondayPercent, decimal tuesdayPercent, 
            decimal wednesdayPercent, decimal thursdayPercent, decimal fridayPercent, decimal saturdayPercent)
        {
            SundayPercent = sundayPercent;
            MondayPercent = mondayPercent;
            TuesdayPercent = tuesdayPercent;
            WednesdayPercent = wednesdayPercent;
            ThursdayPercent = thursdayPercent;
            FridayPercent = fridayPercent;
            SaturdayPercent = saturdayPercent;
        }

        protected decimal SundayPercent { get; }
        protected decimal MondayPercent { get; }
        protected decimal TuesdayPercent { get; }
        protected decimal WednesdayPercent { get; }
        protected decimal ThursdayPercent { get; }
        protected decimal FridayPercent { get; }     
        protected decimal SaturdayPercent { get; }

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