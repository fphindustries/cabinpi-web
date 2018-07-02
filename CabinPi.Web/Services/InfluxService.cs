using CabinPi.Web.Infrastructure;
using CabinPi.Web.Models;
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
    public class InfluxService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppOptions _appOptions;

        public InfluxService(IHttpClientFactory httpClientFactory, IOptions<AppOptions> optionsAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _appOptions = optionsAccessor.Value;
        }

        public async Task<Results> GetSolar()
        {
            return await GetQueries("select * from solar group by * order by desc limit 1",
                "select * from sensors group by * order by desc limit 1");
        }

        private async Task<Results> GetQueries(params string[] queries)
        {
            string[] encodedQueries = new string[queries.Length];
            for(int index = 0; index < queries.Length; index++)
            {
                encodedQueries[index] = WebUtility.UrlEncode(queries[index]);
            }

            string encodedQuery = string.Join(WebUtility.UrlEncode(";"), encodedQueries);

            string url = $"{_appOptions.InfluxServer}/query?db={_appOptions.InfluxDb}&u={_appOptions.InfluxUser}&p={WebUtility.UrlEncode(_appOptions.InfluxPassword)}&q={encodedQuery}";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Results>(response);
        }
    }
}
