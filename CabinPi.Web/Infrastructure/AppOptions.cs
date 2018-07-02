using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinPi.Web.Infrastructure
{
    public class AppOptions
    {
        public string InfluxServer { get; set; }
        public string InfluxDb { get; set; }
        public string InfluxUser { get; set; }
        public string InfluxPassword { get; set; }
        public string DarkSkyKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string WsdotApi { get; set; }
        public string ImageDirectory { get; set; }
    }
}
