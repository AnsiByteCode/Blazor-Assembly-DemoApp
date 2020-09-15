using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashDeskDemoApp.Data.Context;
using CashDeskDemoApp.Data.Models;
using CashDeskDemoApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CashDeskDemoApp.Repositories
{
    /// <summary>
    /// Dashboard Log Repository
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Repositories.Interfaces.IDashboardLogHistoryRepository" />
    public class DashboardLogHistoryRepository : IDashboardLogHistoryRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private CashDeskDemoAppDbContext dbContext;
        /// <summary>
        /// The logger
        /// </summary>
        ILogger<DashboardLogHistoryRepository> logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardLogHistoryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="logger">The logger.</param>
        public DashboardLogHistoryRepository(CashDeskDemoAppDbContext dbContext, ILogger<DashboardLogHistoryRepository> logger)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid values passed for creating history</exception>
        public async Task<DashboardLogHistory> Create(DashboardLogHistory model)
        {
            if (model == null)
            {
                logger.LogError("Invalid values passed for creating history");
                throw new ArgumentException("Invalid values passed for creating history");
            }

            try
            {
                var result = await dbContext.DashboardLogHistory.AddAsync(model);
                await dbContext.SaveChangesAsync().ConfigureAwait(true);
                return model;
            }
            catch (Exception ex)
            {
                logger.LogError($"Create dashboard log history Error: {ex.Message}");
                if (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid value for Id</exception>
        public async Task<string> Delete(string id)
        {
            if (id == null)
            {
                logger.LogError("Invalid value for Id");
                throw new ArgumentException("Invalid value for Id");
            }

            try
            {
                dbContext.Remove(dbContext.DashboardLogHistory.Single(s => s.Id.ToString() == id));
                await dbContext.SaveChangesAsync();
                return id;
            }
            catch (Exception ex)
            {
                logger.LogError($"Delete log history Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<DashboardLogHistory>> GetAll()
        {
            try
            {
                return await dbContext.DashboardLogHistory.OrderByDescending(o => o.CreateDate).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all log history: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<DashboardLogHistory> GetById(string id)
        {
            try
            {
                return await dbContext.DashboardLogHistory.Where(o => o.Id.ToString() == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get log history: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid values passed for updating history</exception>
        public async Task<DashboardLogHistory> Update(DashboardLogHistory model)
        {
            if (model == null)
            {
                logger.LogError("Invalid values passed for updating history");
                throw new ArgumentException("Invalid values passed for updating history");
            }

            try
            {
                var dashboardLogHistory = dbContext.DashboardLogHistory.Where(x => x.Id == model.Id).FirstOrDefault();
                if (dashboardLogHistory != null)
                {
                    dashboardLogHistory = model;
                    var result = dbContext.DashboardLogHistory.Update(dashboardLogHistory);
                    await dbContext.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Update log history Error: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Gets recent logs for users
        /// </summary>
        /// <returns></returns>
        public async Task<List<DashboardLogHistory>> GetRecentLogsForUser(string userId)
        {
            try
            {
                return await dbContext.DashboardLogHistory.Where(x => x.AppUser != null && x.AppUser.Id == userId).OrderByDescending(o => o.CreateDate).Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get log history for user: {ex.Message}");
                throw;
            }
        }
    }
}
