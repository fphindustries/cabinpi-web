using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fphi.CabinPi.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fphi.CabinPi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Telemetry")]
    [AllowAnonymous]
    public class TelemetryController : Controller
    {
        // POST: api/Telemetry
        [HttpPost]
        public void Post([FromBody]Reading[] readings)
        {
            var sensorGroups = readings.GroupBy(r => r.SensorName);
            foreach(var sensorReadings in sensorGroups)
            {
                var readingsByHour = sensorReadings.GroupBy(r => new { r.SampleTime.Date, r.SampleTime.Hour });
                foreach(var reading in readingsByHour)
                {
                    var aggregate = new ReadingAggregate
                    {
                        Sensor = sensorReadings.Key,
                        Time = reading.Key.Date.AddHours(reading.Key.Hour),
                        Samples = reading.Count(),
                        Min = reading.Min(r => r.Value),
                        Average = reading.Average(r => r.Value),
                        Max = reading.Average(r => r.Value)
                    };
                    int i = 9;
                }
            }
        }
    }
}
