using System;
using SC.Domain.Services;
using Xunit;

namespace SC.Domain.Tests
{
    public class PopCategoryCashbackServiceTests
    {
        private static decimal GetCashback(decimal price) 
        {
            var today = DateTime.Now.DayOfWeek;
            
            switch (today)
            {
                case DayOfWeek.Friday: return price * 0.15m; //15%
                case DayOfWeek.Monday: return price * 0.07m; // 7%
                case DayOfWeek.Saturday: return price * 0.20m; // 20%
                case DayOfWeek.Sunday: return price * 0.25m; // 25%
                case DayOfWeek.Thursday: return price * 0.10m; // 10%
                case DayOfWeek.Tuesday: return price * 0.06m; // 6%
                case DayOfWeek.Wednesday: return price * 0.02m; // 2%
                default: return price;
            }
        }

        [Theory]
        [InlineData(45345)]
        [InlineData(12664)]
        [InlineData(6677)]
        public void CalculateCashback(decimal value) 
        {
            var cashbackMock = GetCashback(value);
            var service = new PopCategoryCashbackService().CalculateAmountCashback(value);
            Assert.Equal(cashbackMock, service);
        }
    }
}