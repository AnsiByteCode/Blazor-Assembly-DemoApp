using System.Collections.Generic;
using System.Threading.Tasks;
using CashDeskDemoApp.Shared.Models;

namespace CashDeskDemoApp.Services.External.Interfaces
{
    /// <summary>
    /// Interface for Yahoo Finance Service
    /// </summary>
    public interface IYahooFinanceService
    {
        /// <summary>
        /// Gets the trending tickers.
        /// </summary>
        /// <returns></returns>
        Task<List<TrendingTickers>> GetTrendingTickers();
    }
}
