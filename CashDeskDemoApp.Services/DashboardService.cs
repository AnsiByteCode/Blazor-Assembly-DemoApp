using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CashDeskDemoApp.Data.Models;
using CashDeskDemoApp.Repositories.Interfaces;
using CashDeskDemoApp.Services.External.Interfaces;
using CashDeskDemoApp.Services.Interfaces;
using CashDeskDemoApp.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CashDeskDemoApp.Services
{
    /// <summary>
    /// DashboardService
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Services.Interfaces.IDashBoardService" />
    public class DashboardService : IDashBoardService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;
        /// <summary>
        /// The dashboard log history repository
        /// </summary>
        private readonly IDashboardLogHistoryRepository dashboardLogHistoryRepository;
        /// <summary>
        /// The i ip stack service
        /// </summary>
        private readonly IIPStackService iIPStackService;
        /// <summary>
        /// The exchange rates service
        /// </summary>
        private readonly IExchangeRatesService exchangeRatesService;
        /// <summary>
        /// The yahoo finance service
        /// </summary>
        private readonly IYahooFinanceService yahooFinanceService;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="dashboardLogHistoryRepository">The dashboard log history repository.</param>
        /// <param name="iIPStackService">The i ip stack service.</param>
        /// <param name="exchangeRatesService">The exchange rates service.</param>
        /// <param name="yahooFinanceService">The yahoo finance service.</param>
        public DashboardService(IConfiguration configuration, IDashboardLogHistoryRepository dashboardLogHistoryRepository,
            IIPStackService iIPStackService, IExchangeRatesService exchangeRatesService, IYahooFinanceService yahooFinanceService, UserManager<ApplicationUser> userManager)
        {
            this.configuration = configuration;
            this.dashboardLogHistoryRepository = dashboardLogHistoryRepository;
            this.iIPStackService = iIPStackService;
            this.exchangeRatesService = exchangeRatesService;
            this.yahooFinanceService = yahooFinanceService;
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets the dashboard details.
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <returns></returns>
        public async Task<DashboardResponseViewModel> GetDashboardDetails(string userId)
        {
            var responseModel = new DashboardResponseViewModel();
            var userDetails = await userManager.FindByIdAsync(userId);
            if (userDetails == null)
            {
                return responseModel;
            }
            // get Ip Details
            var ipAddress = await GetIPByRequest();
            if (ipAddress != null)
            {
                var ipStackResponseModel = await iIPStackService.GetLocationDetailsByIP(ipAddress);
                if (ipStackResponseModel != null)
                {
                    responseModel.LocationDetails = new LocationDetails() { IP = ipStackResponseModel.IP, Location = $"{ipStackResponseModel.City}, {ipStackResponseModel.CountryName}, {ipStackResponseModel.ContinentName}" };
                    await dashboardLogHistoryRepository.Create(new DashboardLogHistory()
                    {
                        IP = ipStackResponseModel.IP,
                        CityName = ipStackResponseModel.City,
                        ContinentName = ipStackResponseModel.ContinentName,
                        CountryName = ipStackResponseModel.CountryName,
                        CreateDate = DateTime.UtcNow,
                        Id = Guid.NewGuid(),
                        ZipCode = ipStackResponseModel.Zip,
                        AppUser = userDetails
                    });
                }
                responseModel.TopExchangeRates = await exchangeRatesService.GetLatestExchangeRates();
                responseModel.TrendingTickers = await yahooFinanceService.GetTrendingTickers();
            }
            return responseModel;
        }

        /// <summary>
        /// Gets the recent logs for users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<DashboardLogHistory>> GetRecentLogsForUsers(string userId)
        {
            return await dashboardLogHistoryRepository.GetRecentLogsForUser(userId);
        }

        #region 
        /// <summary>
        /// Gets the ip by request.
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetIPByRequest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Convert.ToString(configuration["CheckIPUrl"]));
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage ipResponse = await client.GetAsync($"/");
                if (ipResponse.IsSuccessStatusCode)
                {
                    var htmlResponse = await ipResponse.Content.ReadAsStringAsync().ConfigureAwait(true);
                    int startIndex = htmlResponse.IndexOf("Address: ") + 9;
                    int lastIndex = htmlResponse.LastIndexOf("</body>");
                    return htmlResponse.Substring(startIndex, lastIndex - startIndex);
                }
            }
            return null;
        }
        #endregion
    }
}
