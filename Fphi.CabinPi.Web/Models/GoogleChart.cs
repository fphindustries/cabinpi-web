

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{
    public class GoogleChartData
    {

        public Col[] cols { get; set; }
        public Row[] rows { get; set; }

        public class Col
        {
            public string id { get; set; }
            public string label { get; set; }
            public string pattern { get; set; }
            public string type { get; set; }
        }

        public class Row
        {
            public C[] c { get; set; }
        }

        public class C
        {
            public object v { get; set; }
            public object f { get; set; }
        }
    }


}
