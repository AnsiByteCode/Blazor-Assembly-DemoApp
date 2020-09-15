using System.Collections.Generic;
using System.Threading.Tasks;
using CashDeskDemoApp.Data.Models;

namespace CashDeskDemoApp.Repositories.Interfaces
{
    /// <summary>
    /// IDashboardLogHistoryRepository interface
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Repositories.Interfaces.IRepository{CashDeskDemoApp.Data.Models.DashboardLogHistory}" />
    public interface IDashboardLogHistoryRepository : IRepository<DashboardLogHistory>
    {
        /// <summary>
        /// Gets the recent logs for user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<List<DashboardLogHistory>> GetRecentLogsForUser(string userId);
    }
}
