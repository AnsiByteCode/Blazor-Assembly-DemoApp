using System.Collections.Generic;
using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Yahoo Response Result
    /// </summary>
    public class YahooResponseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YahooResponseResult"/> class.
        /// </summary>
        public YahooResponseResult()
        {
            Quotes = new List<YahooResponseData>();
        }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets the quotes.
        /// </summary>
        /// <value>
        /// The quotes.
        /// </value>
        [JsonProperty("quotes")]
        public List<YahooResponseData> Quotes { get; set; }
    }
}
