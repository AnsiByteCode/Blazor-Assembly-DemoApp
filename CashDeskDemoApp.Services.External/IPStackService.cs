using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CashDeskDemoApp.Services.External.Interfaces;
using CashDeskDemoApp.Shared.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CashDeskDemoApp.Services.External
{
    /// <summary>
    /// IPStack Helper Service
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Services.External.Interfaces.IIPStackService" />
    public class IPStackService : IIPStackService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="IPStackService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public IPStackService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets the location details by ip.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns></returns>
        public async Task<IPStackResponseViewModel> GetLocationDetailsByIP(string ipAddress)
        {
            if (!string.IsNullOrEmpty(ipAddress))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["IPStackUrl"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage ipResponse = await client.GetAsync($"{ipAddress}?access_key=" + Convert.ToString(configuration["IpStackApiKey"]));
                    if (ipResponse.IsSuccessStatusCode)
                    {
                        var ipModelResponseString = await ipResponse.Content.ReadAsStringAsync().ConfigureAwait(true);
                        return JsonConvert.DeserializeObject<IPStackResponseViewModel>(ipModelResponseString);
                    }
                }
            }
            return null;
        }
    }
}
