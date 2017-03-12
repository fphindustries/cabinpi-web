using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{
    public class ReadingAggregate : TableEntity
    {
        public ReadingAggregate(string sensor, DateTime time)
        {
            this.PartitionKey = sensor;
            this.RowKey = time.ToString("o");
        }
        public ReadingAggregate()        {        }

        public int Samples { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }
        public double Max { get; set; }
    }
}
