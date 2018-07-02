using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinPi.Web.Models
{

    public class Results
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public Series[] series { get; set; }
    }

    public class Series
    {
        public string name { get; set; }
        public Tags tags { get; set; }
        public string[] columns { get; set; }
        public object[][] values { get; set; }

        public double GetDouble(string name, int row)
        {
            var value = values[row][Array.IndexOf<string>(columns, name)];
            if (value is double) return (double)value;

            return Convert.ToDouble(value);
        }

        public string GetString(string name, int row)
        {
            return values[row][Array.IndexOf<string>(columns, name)].ToString();
        }

        public long GetLong(string name, int row)
        {
            var value = values[row][Array.IndexOf<string>(columns, name)];
            if (value is long) return (long)value;

            return Convert.ToInt64(value);
        }

    }

    public class Tags
    {
        public string host { get; set; }
    }

}
