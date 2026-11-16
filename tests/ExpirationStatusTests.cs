using NUnit.Framework;
using PairLab;
using System;

namespace PairLab.Tests
{
    public class ExpirationStatusTests
    {
        [Test]
        public void ExpirationDateNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                ExpirationStatusHelper.ExpirationStatus(
                    null,
                    new DateTime(2025, 10, 1)));
        }

        [Test]
        public void ExpiredDate_ReturnsExpired()
        {
            string result =
                ExpirationStatusHelper.ExpirationStatus(
                    new DateTime(2025, 9, 30),
                    new DateTime(2025, 10, 1));

            Assert.That(result, Is.EqualTo("EXPIRED"));
        }

        [Test]
        public void SameDate_ReturnsUseToday()
        {
            string result =
                ExpirationStatusHelper.ExpirationStatus(
                    new DateTime(2025, 10, 1),
                    new DateTime(2025, 10, 1));

            Assert.That(result, Is.EqualTo("USE_TODAY"));
        }

        [Test]
        public void OneDayRemaining_ReturnsUseSoon()
        {
            string result =
                ExpirationStatusHelper.ExpirationStatus(
                    new DateTime(2025, 10, 2),
                    new DateTime(2025, 10, 1));

            Assert.That(result, Is.EqualTo("USE_SOON"));
        }

        [Test]
        public void ThreeDaysRemaining_ReturnsUseSoon()
        {
            string result =
                ExpirationStatusHelper.ExpirationStatus(
                    new DateTime(2025, 10, 4),
                    new DateTime(2025, 10, 1));

            Assert.That(result, Is.EqualTo("USE_SOON"));
        }

        [Test]
        public void FourDaysRemaining_ReturnsOk()
        {
            string result =
                ExpirationStatusHelper.ExpirationStatus(
                    new DateTime(2025, 10, 5),
                    new DateTime(2025, 10, 1));

            Assert.That(result, Is.EqualTo("OK"));
        }
    }
}