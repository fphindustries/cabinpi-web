using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabinPi.Web.Infrastructure;
using CabinPi.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabinPi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly InfluxService _influx;

        public SensorController(InfluxService influx)
        {
            _influx = influx;
        }

        // GET: api/Api
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var results = await _influx.GetSolar();
            var solarSeries = results.results[0].series[0];
            var tempSeries = results.results[1].series[0];
            var batteryState = solarSeries.GetLong("batteryState", 0);
            var batteryCharge = solarSeries.GetDouble("dispavgVbatt", 0);
            var panelVoltage = solarSeries.GetDouble("dispavgVpv", 0);
            var ampHours = solarSeries.GetLong("AmpHours", 0).ToString();

            var insideTemp = tempSeries.GetDouble("int_f", 0);
            var outsideTemp = tempSeries.GetDouble("ext_f", 0);

            return new JsonResult(new
            {
                batteryState = batteryState.ToBatteryStateDescription(),
                batteryStateClass = batteryState.ToBatteryStateClass(),
                batteryCharge = batteryCharge.ToString("N1"),
                batteryChargeClass = batteryCharge.ToBatteryChargeClass(),
                panelVoltage = panelVoltage.ToString("N1"),
                panelVoltageClass = panelVoltage.ToPanelVoltageClass(),
                ampHours,
                insideTemp = insideTemp.ToString("N1"),
                insideTempClass = insideTemp.ToInsideTempClass(),
                outsideTemp = outsideTemp.ToString("N1"),
                outsideTempClass = outsideTemp.ToOutsideTempClass()
            });


        }
        [HttpGet("History")]
        public async Task<ActionResult> GetHistory()
        {
            var results = await _influx.GetSensorHistory();
            return new JsonResult(results.results[0].series[0]);
        }

        [HttpGet("SolarHistory")]
        public async Task<ActionResult> GetSolarHistory()
        {
            var results = await _influx.GetSolarHistory();
            return new JsonResult(results.results[0].series[0]);
        }
    }
}
