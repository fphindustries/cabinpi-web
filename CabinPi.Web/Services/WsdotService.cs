using CabinPi.Web.Infrastructure;
using CabinPi.Web.Models;
using CabinPi.Web.Models.Wsdot;
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
    public class WsdotService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppOptions _appOptions;

        private const string BaseUrl = "http://wsdot.com/traffic/api/MountainPassConditions/MountainPassConditionsREST.svc/";

        public WsdotService(IHttpClientFactory httpClientFactory, IOptions<AppOptions> optionsAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _appOptions = optionsAccessor.Value;
        }

        public async Task<PassCondition> GetConditions()
        {
            string url = $"{BaseUrl}GetMountainPassConditionAsJon?AccessCode={_appOptions.WsdotApi}&PassConditionID=11";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<PassCondition>(response);
        }
    }
}
