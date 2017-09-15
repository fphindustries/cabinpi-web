using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fphi.CabinPi.Web.Models;
using Fphi.CabinPi.Web.Services;

namespace Fphi.CabinPi.Web.Controllers
{
    public class HomeController : Controller
    {
        private IInfluxService _influx;
        public HomeController(IInfluxService influx)
        {
            _influx = influx;
        }
        public async Task<IActionResult> Index()
        {
           
           var data = await _influx.GetSensorData();
            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
