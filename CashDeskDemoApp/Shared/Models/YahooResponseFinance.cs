using System.Collections.Generic;
using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Yahoo Response Finance
    /// </summary>
    public class YahooResponseFinance
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [JsonProperty("result")]
        public List<YahooResponseResult> Result { get; set; }
    }
}
