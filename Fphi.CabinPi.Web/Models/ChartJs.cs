using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Models
{

    public class ChartJs
    {
        public string type { get; set; }
        public Data data { get; set; }
        public Options options { get; set; }

        public class Data
        {
            public string[] labels { get; set; }
            public Dataset[] datasets { get; set; }

            public class Dataset
            {
                public string label { get; set; }
                public bool? fill { get; set; }
                public float? lineTension { get; set; }
                public string backgroundColor { get; set; }
                public string borderColor { get; set; }
                public string borderCapStyle { get; set; }
                public object[] borderDash { get; set; }
                public float? borderDashOffset { get; set; }
                public string borderJoinStyle { get; set; }
                public string pointBorderColor { get; set; }
                public string pointBackgroundColor { get; set; }
                public int? pointBorderWidth { get; set; }
                public int? pointHoverRadius { get; set; }
                public string pointHoverBackgroundColor { get; set; }
                public string pointHoverBorderColor { get; set; }
                public int? pointHoverBorderWidth { get; set; }
                public int? pointRadius { get; set; }
                public int? pointHitRadius { get; set; }
                public double[] data { get; set; }
                public bool? spanGaps { get; set; }
            }
        }


        public class Options
        {
            public bool responsive { get; set; }
            public Title title { get; set; }
            public Legend legend { get; set; }

            public class Title
            {
                public bool? display { get; set; }
                public string text { get; set; }
            }

            public class Legend
            {
                public bool? display { get; set; }
                public Labels labels { get; set; }

                public class Labels
                {
                    public string fontColor { get; set; }
                }
            }

        }

    }





}
