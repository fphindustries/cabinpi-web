using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{
    public class SensorValue : TableEntity
    {
        public SensorValue(string sensor)
        {
            this.PartitionKey = "Current";
            this.RowKey = sensor;
        }

        public SensorValue() { }

        public DateTime SampleTime { get; set; }
        public double Value { get; set; }
    }
}
