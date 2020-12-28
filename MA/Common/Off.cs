using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Common
{
    public static class Off
    {
        public static uint CalculateOff(uint off, uint price)
        {
            if (off > 0)
            {
                decimal offpersent = Convert.ToDecimal(off) / 100;
                decimal productoff = offpersent * Convert.ToDecimal(price);
                return Convert.ToUInt32(productoff);
            }
            return 0;
        }
    }
}
