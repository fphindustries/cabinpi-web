using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{
    public class ReadingAggregate
    {
        public string Sensor { get; set; }
        public DateTime Time { get; set; }
        public int Samples { get; set; }
        public float Min { get; set; }
        public float Average { get; set; }
        public float Max { get; set; }
    }
}
