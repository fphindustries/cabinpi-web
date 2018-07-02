using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabinPi.Web.Infrastructure;
using CabinPi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CabinPi.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string BatteryState { get; set; }
        public string BatteryCharge { get; set; }
        public string PanelVoltage { get; set; }
        public string AmpHours { get; set; }

        public string InsideTemp { get; set; }
        public string OutsideTemp { get; set; }

        private readonly InfluxService _influx;

        public IndexModel(InfluxService influx)
        {
            _influx = influx;
        }

        public async Task OnGetAsync()
        {
            var results = await _influx.GetSolar();
            var solarSeries = results.results[0].series[0];
            var tempSeries = results.results[1].series[0];
            BatteryState = solarSeries.GetLong("batteryState", 0).ToBatteryStateDescription();
            BatteryCharge = solarSeries.GetDouble("dispavgVbatt", 0).ToString();
            PanelVoltage = solarSeries.GetDouble("dispavgVpv", 0).ToString();
            AmpHours = solarSeries.GetLong("AmpHours", 0).ToString();

            InsideTemp = tempSeries.GetDouble("int_f", 0).ToString();
            OutsideTemp = tempSeries.GetDouble("ext_f", 0).ToString();
        }
    }
}
