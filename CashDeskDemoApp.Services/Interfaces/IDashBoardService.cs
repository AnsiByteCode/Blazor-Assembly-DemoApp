using System.Collections.Generic;
using System.Threading.Tasks;
using CashDeskDemoApp.Data.Models;
using CashDeskDemoApp.Shared.Models;

namespace CashDeskDemoApp.Services.Interfaces
{
    /// <summary>
    /// IDashBoardService Interface
    /// </summary>
    public interface IDashBoardService
    {
        /// <summary>
        /// Gets the dashboard details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<DashboardResponseViewModel> GetDashboardDetails(string userId);

        /// <summary>
        /// Gets the recent logs for users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<List<DashboardLogHistory>> GetRecentLogsForUsers(string userId);
    }
}
