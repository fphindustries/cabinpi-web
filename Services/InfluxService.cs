using Fphi.CabinPi.Web.Models;
using Microsoft.Extensions.Configuration;
using InfluxDB.Net;
using System.Threading.Tasks;
using System;

namespace Fphi.CabinPi.Web.Services
{
    public class InfluxService: IInfluxService
    {
        private IConfiguration _configuration;
        public InfluxService(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public async Task<SensorData> GetSensorData()
        {
            var client = GetClient();
            var series = await client.QueryAsync(_configuration["InfluxDb"],
                "SELECT LAST(fahrenheit) as temp FROM sht31");
            return new SensorData{
                InteriorTemperature= (double)series[0].Values[0][1]
            };

        }

        private InfluxDb GetClient()
        {
            return new InfluxDb(
                _configuration["InfluxUrl"],
                _configuration["InfluxUser"],
                _configuration["InfluxPassword"]
            );
        }
    }
}