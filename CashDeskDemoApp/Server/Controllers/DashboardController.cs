using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashDeskDemoApp.Data.Models;
using CashDeskDemoApp.Services.Interfaces;
using CashDeskDemoApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CashDeskDemoApp.Server.Controllers
{
    /// <summary>
    /// Dashboard Controller
    /// </summary>
    /// <seealso cref="CashDeskDemoApp.Server.Controllers.BaseController" />
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : BaseController
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DashboardController> logger;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// The dash board service
        /// </summary>
        private readonly IDashBoardService _dashBoardService;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="baseLogger">The base logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="dashBoardService">The dash board service.</param>
        /// <param name="userManager">The user manager.</param>
        public DashboardController(ILogger<DashboardController> logger, IHttpContextAccessor httpContextAccessor, ILogger<BaseController> baseLogger, IConfiguration configuration, IDashBoardService dashBoardService, UserManager<ApplicationUser> userManager) : base(baseLogger, httpContextAccessor, configuration)
        {
            this.logger = logger;
            this._httpContextAccessor = httpContextAccessor;
            this._dashBoardService = dashBoardService;
            this._userManager = userManager;
        }

        /// <summary>
        /// Gets the dash board details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DashboardResponseViewModel> GetDashBoardDetails()
        {
            var dashBoardResponseModel = await _dashBoardService.GetDashboardDetails(GetIdentityUserId());
            return dashBoardResponseModel;
        }

        /// <summary>
        /// Gets the log history.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("loghistory")]
        public async Task<List<LocationDetails>> GetLogHistory()
        {
            var dashBoardHistory = await _dashBoardService.GetRecentLogsForUsers(GetIdentityUserId());
            return dashBoardHistory.Select(x => new LocationDetails()
            {
                IP =x.IP,
                Location = $"{x.CityName}, {x.CountryName}, {x.ContinentName}",
                CreateDate = x.CreateDate
            }).ToList();
        }
    }
}
