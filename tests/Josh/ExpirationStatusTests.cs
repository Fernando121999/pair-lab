
using System;
using Xunit;
using PairLabJC;

namespace PairLabJC.Tests
{
    public class ExpirationStatusTests
    {
        [Fact]
        public void TestExpired()
        {
            DateTime day = new DateTime(2026, 11, 18);
            DateTime expirationDate = new DateTime(2026, 11, 17);

            string result = ExpirationStatus.ExpirationStatusCal(expirationDate, day);

            Assert.Equal("EXPIRED", result);
        }

        [Fact]
        public void TestUseToday()
        {
            DateTime day = new DateTime(2026, 11, 18);

            string result = ExpirationStatus.ExpirationStatusCal(day, day);

            Assert.Equal("USE_TODAY", result);
        }

        [Fact]
        public void TestUseSoon()
        {
            DateTime day = new DateTime(2026, 11, 18);
            DateTime expirationDate = new DateTime(2026, 11, 20);

            string result = ExpirationStatus.ExpirationStatusCal(expirationDate, day);

            Assert.Equal("USE_SOON", result);
        }

        [Fact]
        public void TestOK()
        {
            DateTime day = new DateTime(2026, 11, 18);
            DateTime expirationDate = new DateTime(2026, 11, 25);

            string result = ExpirationStatus.ExpirationStatusCal(expirationDate, day);

            Assert.Equal("OK", result);
        }

     
    }
}
