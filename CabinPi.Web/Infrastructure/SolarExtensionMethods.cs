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

        public static string ToBatteryStateClass(this long state)
        {
            switch (state)
            {
                case 0:
                    return "light";
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 10:
                case 18:
                    return "success";
                default: return "danger";
            }
        }

        public static string ToBatteryChargeClass(this double voltage)
        {
            if (voltage > 12.5)
                return "success";
            else if (voltage > 12.0)
                return "warning";
            else
                return "danger";
        }

        public static string ToInsideTempClass(this double temperature)
        {
            if (temperature > 90)
                return "danger";
            else if (temperature > 80)
                return "warning";
            else if (temperature < 50)
                return "warning";
            else if (temperature < 32)
                return "danger";
            else
                return "success";
        }
        public static string ToOutsideTempClass(this double temperature)
        {
            if (temperature > 100)
                return "danger";
            else if (temperature > 90)
                return "warning";
            else if (temperature < 32)
                return "info";
            else
                return "success";
        }

        public static string ToPanelVoltageClass(this double voltage)
        {
            if (voltage > 0)
                return "success";

            return "light";
        }

    }
}
