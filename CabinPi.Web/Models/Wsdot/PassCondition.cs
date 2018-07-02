using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinPi.Web.Models.Wsdot
{

    public class PassCondition
    {
        public DateTime DateUpdated { get; set; }
        public int ElevationInFeet { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int MountainPassId { get; set; }
        public string MountainPassName { get; set; }
        public TravelRestriction RestrictionOne { get; set; }
        public TravelRestriction RestrictionTwo { get; set; }
        public string RoadCondition { get; set; }
        public int TemperatureInFahrenheit { get; set; }
        public bool TravelAdvisoryActive { get; set; }
        public string WeatherCondition { get; set; }
    }

    public class TravelRestriction
    {
        public string RestrictionText { get; set; }
        public string TravelDirection { get; set; }
    }
}
