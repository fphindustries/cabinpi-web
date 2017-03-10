using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{
    public class Reading
    {
        public string SensorName { get; set; }
        public DateTime SampleTime { get; set; }
        public float Value { get; set; }
    }
}
