using System;

namespace PairLab;

public static class ApplyCouponHelper
{
    public static decimal ApplyCoupon(
        decimal subtotal,
        string couponType,
        decimal value,
        decimal minimumSpend)
    {
        if (couponType == "PERCENT")
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException("Invalid percent value.");
            }
        }
        else if (couponType == "DOLLAR")
        {
            if (value < 0.01m || value > 100.00m)
            {
                throw new ArgumentException("Invalid dollar value.");
            }
        }
        else
        {
            throw new ArgumentException("Unknown coupon type.");
        }

        if (subtotal < minimumSpend)
        {
            return Math.Round(subtotal, 2);
        }

        decimal total;

        if (couponType == "PERCENT")
        {
            total = subtotal * (1 - value / 100m);
        }
        else
        {
            total = subtotal - value;
        }

        if (total < 0)
        {
            total = 0;
        }

        return Math.Round(total, 2);
    }
}