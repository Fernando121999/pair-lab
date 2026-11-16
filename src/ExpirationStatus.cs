using System;

namespace PairLab
{
    public static class ExpirationStatusHelper
    {
        public static string ExpirationStatus(DateTime? expirationDate, DateTime today)
        {
            if (expirationDate == null)
            {
                throw new ArgumentException("Expiration date is required.");
            }

            int days = (expirationDate.Value.Date - today.Date).Days;

            if (days < 0)
            {
                return "EXPIRED";
            }

            if (days == 0)
            {
                return "USE_TODAY";
            }

            if (days >= 1 && days <= 3)
            {
                return "USE_SOON";
            }

            return "OK";
        }
    }
}