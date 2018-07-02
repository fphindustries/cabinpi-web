using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinPi.Web.Infrastructure
{
    public static class SolarExtensionMethods
    {
        public static string ToBatteryStateDescription(this long state)
        {
            switch (state)
            {
                case 0: return "Resting";
                case 3: return "Absorb";
                case 4: return "Bulk MPPT";
                case 5: return "Float";
                case 6: return "Float MPPT";
                case 7: return "Equalize";
                case 10: return "Hyper VOC";
                case 18: return "Equalize MPPT";
                default: return "Unknown";
            }
        }
    }
}
