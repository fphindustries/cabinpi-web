using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabinPi.Web.Models.DarkSky;
using CabinPi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CabinPi.Web.Pages
{
    public class ForecastModel : PageModel
    {
        private readonly DarkSkyService _darkSky;
        public Models.DarkSky.Forecast Forecast { get; set; }

        public ForecastModel(DarkSkyService darkSky)
        {
            _darkSky = darkSky;
        }
        public async Task OnGetAsync()
        {
            Forecast = await _darkSky.GetForecast();

            // Clear to testing layout
            //Forecast.Alerts = new List<Models.DarkSky.Alert>();
            //var alert = new Alert()
            //{
            //    Title = "Flood Watch for Mason, WA",
            //    UnixTime = 1509993360,
            //    UnixExpires = 1510036680,
            //    Description = "...FLOOD WATCH REMAINS IN EFFECT THROUGH LATE MONDAY NIGHT...\nTHE FLOOD WATCH CONTINUES FOR\n* A PORTION OF NORTHWEST WASHINGTON...INCLUDING THE FOLLOWING\nCOUNTY...MASON.\n* THROUGH LATE FRIDAY NIGHT\n* A STRONG WARM FRONT WILL BRING HEAVY RAIN TO THE OLYMPICS\nTONIGHT THROUGH THURSDAY NIGHT. THE HEAVY RAIN WILL PUSH THE\nSKOKOMISH RIVER ABOVE FLOOD STAGE TODAY...AND MAJOR FLOODING IS\nPOSSIBLE.\n* A FLOOD WARNING IS IN EFFECT FOR THE SKOKOMISH RIVER. THE FLOOD\nWATCH REMAINS IN EFFECT FOR MASON COUNTY FOR THE POSSIBILITY OF\nAREAL FLOODING ASSOCIATED WITH A MAJOR FLOOD.\n"
            //};
            //Forecast.Alerts.Add(alert);


        }
    }
}