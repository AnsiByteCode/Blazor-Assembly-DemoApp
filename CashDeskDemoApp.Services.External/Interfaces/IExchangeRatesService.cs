using System.Collections.Generic;
using System.Threading.Tasks;
using CashDeskDemoApp.Shared.Models;

namespace CashDeskDemoApp.Services.External.Interfaces
{
    /// <summary>
    /// IExchangeRatesService interface
    /// </summary>
    public interface IExchangeRatesService
    {
        /// <summary>
        /// Gets the latest exchange rates.
        /// </summary>
        /// <returns></returns>
        Task<List<ExchangeRates>> GetLatestExchangeRates();
    }
}
