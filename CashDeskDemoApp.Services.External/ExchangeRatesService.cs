using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CashDeskDemoApp.Services.External.Interfaces;
using CashDeskDemoApp.Shared.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CashDeskDemoApp.Services.External
{
    /// <summary>
    /// ExchangeRatesService implementation
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Services.External.Interfaces.IExchangeRatesService" />
    public class ExchangeRatesService : IExchangeRatesService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRatesService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ExchangeRatesService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Gets the latest exchange rates.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExchangeRates>> GetLatestExchangeRates()
        {
            var format = "yyyy-MM-dd";
            string startDate = DateTime.UtcNow.AddDays(-5).ToString(format);
            string endDate = DateTime.UtcNow.ToString(format);

            string baseurl = $"history?start_at={startDate}&end_at={endDate}&base=USD";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["ExchnageRatesApiUrl"]);
                var clientResponse = await client.GetAsync(baseurl);
                if (clientResponse.IsSuccessStatusCode)
                {
                    var exchangeRatesJsonString = await clientResponse.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<ExchangeRatesResponseViewModel>(exchangeRatesJsonString);
                    if (responseModel.Rates.Count >= 2)
                    {
                        var ratesDateRange = GetLatestDatesByResponse(responseModel, format);
                        var rates = responseModel.Rates.Where(x => ratesDateRange.FirstOrDefault() == x.Key).Select(x => x.Value).FirstOrDefault();
                        var prevRates = responseModel.Rates.Where(x => ratesDateRange.LastOrDefault() == x.Key).Select(x => x.Value).FirstOrDefault();
                        List<ExchangeRates> exchangeRates = new List<ExchangeRates>();
                        foreach (var dataItem in rates.Take(10))
                        {
                            var prevRatesValue = prevRates.Where(x => x.Key == dataItem.Key).Select(x => x.Value).FirstOrDefault();
                            var diffValue = dataItem.Value - prevRatesValue;
                            exchangeRates.Add(new ExchangeRates()
                            {
                                Currency = dataItem.Key,
                                DiffValue = diffValue,
                                LatestValue = dataItem.Value
                            });
                        }
                        return exchangeRates;
                    }
                }
            }
            return null;
        }

        #region Private methods
        /// <summary>
        /// Gets the latest dates by response.
        /// </summary>
        /// <param name="responseModel">The response model.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        private List<string> GetLatestDatesByResponse(ExchangeRatesResponseViewModel responseModel, string format)
        {
            var datesList = responseModel.Rates.Select(x => DateTime.ParseExact(x.Key, format, CultureInfo.InvariantCulture)).OrderByDescending(x => x).Select(x => x.ToString(format)).Take(2);
            return datesList.ToList();
        }
        #endregion
    }
}
