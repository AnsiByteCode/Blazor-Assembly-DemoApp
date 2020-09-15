namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Exchange Rates
    /// </summary>
    public class ExchangeRates
    {
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string Currency { get; set; }
        /// <summary>
        /// Gets or sets the latest value.
        /// </summary>
        /// <value>
        /// The latest value.
        /// </value>
        public double LatestValue { get; set; }
        /// <summary>
        /// Gets or sets the difference value.
        /// </summary>
        /// <value>
        /// The difference value.
        /// </value>
        public double DiffValue { get; set; }
    }
}
