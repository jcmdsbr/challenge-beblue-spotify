using System;
using SC.Domain.Services;
using Xunit;

namespace SC.Domain.Tests
{
    public class MpbCategoryCashbackServiceTests
    {
        private static decimal GetCashback(decimal price) 
        {
            var today = DateTime.Now.DayOfWeek;
        
            switch (today)
            {
                case DayOfWeek.Friday: return price * 0.25m; //25%
                case DayOfWeek.Monday: return price * 0.05m; // 5%
                case DayOfWeek.Saturday: return price * 0.30m; // 30%
                case DayOfWeek.Sunday: return price * 0.30m; // 30%
                case DayOfWeek.Thursday: return price * 0.20m; // 10%
                case DayOfWeek.Tuesday: return price * 0.10m; // 10%
                case DayOfWeek.Wednesday: return price * 0.15m; // 15%
                default: return price;
            }
        }

        [Theory]
        [InlineData(23)]
        [InlineData(1234)]
        [InlineData(66.6)]
        public void CalculateCashback(decimal value) 
        {
            var cashbackMock = GetCashback(value);
            var service = new MpbCategoryCashbackService().CalculateAmountCashback(value);
            Assert.Equal(cashbackMock, service);
        }
    }
}