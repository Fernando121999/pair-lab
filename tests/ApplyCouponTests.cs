using NUnit.Framework;
using PairLab;
using System;

namespace PairLab.Tests;

public class ApplyCouponTests
{
    [Test]
    public void UnknownCouponType_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            ApplyCouponHelper.ApplyCoupon(
                100m,
                "BOGO",
                10m,
                0m));
    }

    [Test]
    public void PercentBelowOne_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            ApplyCouponHelper.ApplyCoupon(
                100m,
                "PERCENT",
                0m,
                0m));
    }

    [Test]
    public void PercentDiscountAppliedCorrectly()
    {
        decimal result =
            ApplyCouponHelper.ApplyCoupon(
                100m,
                "PERCENT",
                10m,
                0m);

        Assert.That(result, Is.EqualTo(90m));
    }

    [Test]
    public void DollarDiscountAppliedCorrectly()
    {
        decimal result =
            ApplyCouponHelper.ApplyCoupon(
                100m,
                "DOLLAR",
                20m,
                0m);

        Assert.That(result, Is.EqualTo(80m));
    }

    [Test]
    public void MinimumSpendNotMet_NoDiscountApplied()
    {
        decimal result =
            ApplyCouponHelper.ApplyCoupon(
                20m,
                "DOLLAR",
                10m,
                50m);

        Assert.That(result, Is.EqualTo(20m));
    }

    [Test]
    public void TotalCannotGoBelowZero()
    {
        decimal result =
            ApplyCouponHelper.ApplyCoupon(
                5m,
                "DOLLAR",
                20m,
                0m);

        Assert.That(result, Is.EqualTo(0m));
    }

    [Test]
    public void ResultIsRoundedToTwoDecimals()
    {
        decimal result =
            ApplyCouponHelper.ApplyCoupon(
                99.99m,
                "PERCENT",
                33m,
                0m);

        Assert.That(result, Is.EqualTo(66.99m));
    }
}