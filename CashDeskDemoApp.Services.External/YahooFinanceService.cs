using System;
using System.Collections.Generic;
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
    /// Service for YahooFinanceService
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Services.External.Interfaces.IYahooFinanceService" />
    public class YahooFinanceService : IYahooFinanceService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="YahooFinanceService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public YahooFinanceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets the trending tickers.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TrendingTickers>> GetTrendingTickers()
        {
            string url = $"market/get-trending-tickers";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["YahooFinanceApiUrl"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", configuration["YahooFinanceApiHost"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", configuration["YahooFinanceApiKey"]);
                client.DefaultRequestHeaders.Add("useQueryString", "true");

                var responseFromYahooApi = await client.GetAsync(configuration["YahooFinanceApiUrl"] + url);
                var jsonResponseFromYahooApi = await responseFromYahooApi.Content.ReadAsStringAsync();
                var tickersResponse = JsonConvert.DeserializeObject<YahooResponseTrendingTickers>(jsonResponseFromYahooApi);
                List<TrendingTickers> trendingTickers = new List<TrendingTickers>();
                var tickersList = tickersResponse.Finance.Result[0].Quotes.Take(10).ToList();
                foreach (var item in tickersList)
                {
                    trendingTickers.Add(new TrendingTickers()
                    {
                        MarketChange = item.RegularMarketChange,
                        MarketPrice = item.RegularMarketPrice,
                        MarketChangePercent = item.RegularMarketChangePercent,
                        Name = item.LongName,
                        Symbol = item.Symbol
                    });
                }
                return trendingTickers;
            }
        }
    }
}
