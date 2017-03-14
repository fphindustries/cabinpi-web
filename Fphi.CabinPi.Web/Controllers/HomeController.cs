using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fphi.CabinPi.Web.Services;
using Fphi.CabinPi.Web.Models;
using Newtonsoft.Json;

namespace Fphi.CabinPi.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICabinRepository _repo;

        public HomeController(ICabinRepository cabinRepository)
        {
            _repo = cabinRepository;
        }
        public IActionResult Index()
        {
            return View(_repo.GetCurrentSensorValues());
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

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ChartData(string sensorName)
        {
            GoogleChartData chartData = new GoogleChartData();
            chartData.cols = new GoogleChartData.Col[] {
                new GoogleChartData.Col() { id = "", label = "Date", pattern = "", type = "date" },
                new GoogleChartData.Col() { id = "", label = "Temp", pattern = "", type = "number" }
            };
            List<ReadingAggregate> sensorData = _repo.GetSensorData(sensorName);
            chartData.rows = sensorData.Select(d => new GoogleChartData.Row
            {
                c = new GoogleChartData.C[] {
                    new GoogleChartData.C{ v=$"Date({DateTime.Parse(d.RowKey).Year},{DateTime.Parse(d.RowKey).Month},{DateTime.Parse(d.RowKey).Day}, {DateTime.Parse(d.RowKey).Hour}, {DateTime.Parse(d.RowKey).Minute})"},
                    new GoogleChartData.C{ v=d.Average}
                }
            }).ToArray();
            return Json(chartData);
        }

        public IActionResult TempChartData()
        {
            List<ReadingAggregate> sensorData = _repo.GetSensorData("InsideTemp");
            var labels = sensorData.OrderBy(d => d.RowKey).Select(d => DateTime.Parse(d.RowKey).ToString("hh:mm")).ToArray();
            var data = sensorData.OrderBy(d => d.RowKey).Select(d => d.Average).ToArray();
            ChartJs chart = new ChartJs();
            chart.type = "line";
            chart.data = new ChartJs.Data()
            {
                labels = labels,
                datasets = new ChartJs.Data.Dataset[]
                {
                    new ChartJs.Data.Dataset
                    {
                        label="Temp",
                        data=data
                    }
                }
            };
            return Json(chart, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public IActionResult PowerChartData()
        {
            List<ReadingAggregate> sensorData = _repo.GetSensorData("PimWatts");
            var labels = sensorData.OrderBy(d => d.RowKey).Select(d => DateTime.Parse(d.RowKey).ToString("hh:mm")).ToArray();
            var data = sensorData.OrderBy(d => d.RowKey).Select(d => d.Average).ToArray();
            ChartJs chart = new ChartJs();
            chart.type = "line";
            chart.data = new ChartJs.Data()
            {
                labels = labels,
                datasets = new ChartJs.Data.Dataset[]
                {
                    new ChartJs.Data.Dataset
                    {
                        label="milliWatts",
                        data=data
                    }
                }
            };
            return Json(chart, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
