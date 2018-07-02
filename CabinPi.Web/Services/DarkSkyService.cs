using CabinPi.Web.Infrastructure;
using CabinPi.Web.Models;
using CabinPi.Web.Models.DarkSky;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CabinPi.Web.Services
{
    public class DarkSkyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppOptions _appOptions;

        private const string BaseUrl = "https://api.darksky.net/forecast/";

        public DarkSkyService(IHttpClientFactory httpClientFactory, IOptions<AppOptions> optionsAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _appOptions = optionsAccessor.Value;
        }

        public async Task<Forecast> GetForecast()
        {
            string url = $"{BaseUrl}{_appOptions.DarkSkyKey}/{_appOptions.Latitude},{_appOptions.Longitude}?exclude=minutely";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Forecast>(response);
        }
    }
}
