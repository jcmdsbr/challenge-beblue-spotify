using System;
using SC.Domain.Services;
using Xunit;

namespace SC.Domain.Tests
{
    public class ClassicCategoryCashbackServiceTests
    {
        
        private static decimal GetCashback(decimal price) 
        {
            var today = DateTime.Now.DayOfWeek;

            switch (today)
            {
                case DayOfWeek.Friday: return price * 0.25m; //25%
                case DayOfWeek.Monday: return price * 0.03m; // 3%
                case DayOfWeek.Saturday: return price * 0.18m; // 18%
                case DayOfWeek.Sunday: return price * 0.35m; // 35%
                case DayOfWeek.Thursday: return price * 0.13m; // 13%
                case DayOfWeek.Tuesday: return price * 0.05m; // 5%
                case DayOfWeek.Wednesday: return price * 0.08m; // 8%
                default: return price;
            }
        }

        [Theory]
        [InlineData(100)]
        [InlineData(999.99)]
        [InlineData(50.5)]
        public void CalculateCashback(decimal value) 
        {
            var cashbackMock = GetCashback(value);
            var service = new ClassicCategoryCashbackService().CalculateAmountCashback(value);
            Assert.Equal(cashbackMock, service);
        }
    }
}