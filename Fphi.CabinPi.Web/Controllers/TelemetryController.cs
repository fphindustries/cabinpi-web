using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fphi.CabinPi.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Fphi.CabinPi.Web.Services;

namespace Fphi.CabinPi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Telemetry")]
    [AllowAnonymous]
    public class TelemetryController : Controller
    {
        private ICabinRepository _repo;
        public TelemetryController(ICabinRepository cabinRepository)
        {
            _repo = cabinRepository;
        }
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
                    var aggregate = new ReadingAggregate(sensorReadings.Key, reading.Key.Date.AddHours(reading.Key.Hour))
                    {
                        Samples = reading.Count(),
                        Min = reading.Min(r => r.Value),
                        Average = reading.Average(r => r.Value),
                        Max = reading.Max(r => r.Value)
                    };
                    _repo.AddSensorData(aggregate);
                }
            }
        }
    }
}
