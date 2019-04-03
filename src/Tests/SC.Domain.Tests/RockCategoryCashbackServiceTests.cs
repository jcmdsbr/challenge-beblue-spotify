using System;
using SC.Domain.Services;
using Xunit;

namespace SC.Domain.Tests
{
    public class RockCategoryCashbackServiceTests
    {
         private static decimal GetCashback(decimal price) 
        {
            var today = DateTime.Now.DayOfWeek;
            
            switch (today)
            {
                case DayOfWeek.Friday: return price * 0.20m; //15%
                case DayOfWeek.Monday: return price * 0.10m; // 10%
                case DayOfWeek.Saturday: return price * 0.40m; // 40%
                case DayOfWeek.Sunday: return price * 0.40m; // 40%
                case DayOfWeek.Thursday: return price * 0.15m; // 15%
                case DayOfWeek.Tuesday: return price * 0.15m; // 15%
                case DayOfWeek.Wednesday: return price * 0.15m; // 15%
                default: return price;
            }
        }

        [Theory]
        [InlineData(123)]
        [InlineData(435)]
        [InlineData(56443)] 
        public void CalculateCashback(decimal value) 
        {
            var cashbackMock = GetCashback(value);
            var service = new RockCategoryCashbackService().CalculateAmountCashback(value);
            Assert.Equal(cashbackMock, service);
        }
    }
}