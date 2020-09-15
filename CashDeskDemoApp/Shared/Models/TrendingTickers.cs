namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Trending Tickers
    /// </summary>
    public class TrendingTickers
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the market price.
        /// </summary>
        /// <value>
        /// The market price.
        /// </value>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// Gets or sets the market change.
        /// </summary>
        /// <value>
        /// The market change.
        /// </value>
        public decimal MarketChange { get; set; }
        /// <summary>
        /// Gets or sets the market change percent.
        /// </summary>
        /// <value>
        /// The market change percent.
        /// </value>
        public decimal MarketChangePercent { get; set; }
    }
}
