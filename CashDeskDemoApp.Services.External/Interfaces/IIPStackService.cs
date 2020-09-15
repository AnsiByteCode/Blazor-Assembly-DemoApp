using System.Threading.Tasks;
using CashDeskDemoApp.Shared.Models;

namespace CashDeskDemoApp.Services.External.Interfaces
{
    /// <summary>
    /// IIPStackService interface
    /// </summary>
    public interface IIPStackService
    {
        /// <summary>
        /// Gets the location details by ip.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns></returns>
        Task<IPStackResponseViewModel> GetLocationDetailsByIP(string ipAddress);
    }
}
