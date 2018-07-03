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
            return await GetQueries("select * from solar where time > now() - 1h group by * order by desc limit 1",
                "select * from sensors where time > now() - 1h group by * order by desc limit 1");
        }

        public async Task<Results> GetSensorHistory()
        {
            //return await GetQueries("select mean(case_c) AS case_c, mean(case_f) AS case_f, mean(ext_c) as ext_c, mean(ext_f) as ext_f, mean(hPa) as hPa, mean(humidity) as humidity, mean(inHg) as inHg, mean(int_c) as int_c, mean(int_f) as int_f, mean(pi_i) as pi_i, mean(pi_v) as pi_v, mean(pi_w) as pi_w from sensors where time > now() - 1d group by time(1h)");
            return await GetQueries("select mean(ext_f) as ext_f, mean(int_f) as int_f from sensors where time > now() - 1d group by time(1h)");
        }

        public async Task<Results> GetSolarHistory()
        {
            return await GetQueries("select mean(dispavgVbatt) as dispavgVbatt, mean(dispavgVpv) as dispavgVpv, mean(AmpHours) as AmpHours from solar where time > now() - 1d group by time(1h)");
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
