using System;

namespace PairLabJC
{
    public static class ExpirationStatus
    {
        public static string ExpirationStatusCal (DateTime? expirationDate, DateTime day)
        {
            
            if (expirationDate == null)
            {
                throw new ArgumentException("Must have a expiration date");
            }
            int DaysRemain = (expirationDate.Value.Date-day.Date).Days;
            if (DaysRemain < 0)
            {
                return "EXPIRED";
            }
            if (DaysRemain == 0)
            {
                return "USE_TODAY";
            }
            if (DaysRemain <= 3 )
            {
                return "USE_SOON";
            }
            else
            return "OK";
            
    
            
            
        }
    }
}