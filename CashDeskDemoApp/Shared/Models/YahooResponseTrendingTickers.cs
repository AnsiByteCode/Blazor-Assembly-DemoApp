using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// YahooResponseTrendingTickers
    /// </summary>
    public class YahooResponseTrendingTickers
    {
        [JsonProperty("finance")]
        public YahooResponseFinance Finance { get; set; }
    }
}
