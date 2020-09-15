using System.Collections.Generic;
using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Exchange Rates Response View Model
    /// </summary>
    public class ExchangeRatesResponseViewModel
    {
        /// <summary>
        /// Gets or sets the rates.
        /// </summary>
        /// <value>
        /// The rates.
        /// </value>
        [JsonProperty("rates")]
        public Dictionary<string, Dictionary<string, double>> Rates { get; set; }

        /// <summary>
        /// Gets or sets the start at.
        /// </summary>
        /// <value>
        /// The start at.
        /// </value>
        [JsonProperty("start_at")]
        public string StartAt { get; set; }

        /// <summary>
        /// Gets or sets the end at.
        /// </summary>
        /// <value>
        /// The end at.
        /// </value>
        [JsonProperty("end_at")]
        public string EndAt { get; set; }
    }
}
