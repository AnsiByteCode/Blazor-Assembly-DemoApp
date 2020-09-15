using System.Collections.Generic;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// Dashboard Response View Model
    /// </summary>
    public class DashboardResponseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardResponseViewModel"/> class.
        /// </summary>
        public DashboardResponseViewModel()
        {
            TopExchangeRates = new List<ExchangeRates>();
            TrendingTickers = new List<TrendingTickers>();
        }
        /// <summary>
        /// Gets or sets the location details.
        /// </summary>
        /// <value>
        /// The location details.
        /// </value>
        public LocationDetails LocationDetails { get; set; }
        /// <summary>
        /// Gets or sets the top exchange rates.
        /// </summary>
        /// <value>
        /// The top exchange rates.
        /// </value>
        public List<ExchangeRates> TopExchangeRates { get; set; }
        /// <summary>
        /// Gets or sets the trending tickers.
        /// </summary>
        /// <value>
        /// The trending tickers.
        /// </value>
        public List<TrendingTickers> TrendingTickers { get; set; }
    }
}
