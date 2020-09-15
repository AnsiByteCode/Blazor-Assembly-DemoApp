using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace CashDeskDemoApp.Server.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<BaseController> logger;

        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="configuration">The configuration.</param>
        public BaseController(ILogger<BaseController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.logger = logger;
            this._httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets the identity user identifier.
        /// </summary>
        /// <returns></returns>
        public string GetIdentityUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        #region private methods

        /// <summary>
        /// Gets the request ip.
        /// </summary>
        /// <param name="tryUseXForwardHeader">if set to <c>true</c> [try use x forward header].</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unable to determine caller's IP.</exception>
        public string GetRequestIP(bool tryUseXForwardHeader = true)
        {
            string ipAddress = null;
            try
            {
                if (tryUseXForwardHeader)
                {
                    ipAddress = SplitCsv(GetHeaderValueAs<string>("X-Forwarded-For")).FirstOrDefault();
                }

                // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
                if (string.IsNullOrEmpty(ipAddress) && _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
                    ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                if (string.IsNullOrEmpty(ipAddress))
                    ipAddress = GetHeaderValueAs<string>("REMOTE_ADDR");

                // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.
                if (string.IsNullOrEmpty(ipAddress))
                    throw new Exception("Unable to determine caller's IP.");

                if (ipAddress == "::1") // specifically return for localhost only
                {
                    WebRequest request = WebRequest.Create(Convert.ToString(configuration["CheckIPUrl"]));
                    using (WebResponse response = request.GetResponse())
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        var address = stream.ReadToEnd();
                        int first = address.IndexOf("Address: ") + 9;
                        int last = address.LastIndexOf("</body>");
                        ipAddress = address.Substring(first, last - first);
                    }
                }

                if (ipAddress.Contains(":"))
                {
                    ipAddress = ipAddress.Substring(0, ipAddress.IndexOf(':'));
                }
            }
            catch (Exception ex)
            {
                logger.LogError("error occurred while getting Ip: " + ex.StackTrace);
            }
            return ipAddress;
        }

        /// <summary>
        /// Splits the CSV.
        /// </summary>
        /// <param name="csvList">The CSV list.</param>
        /// <param name="nullOrWhitespaceInputReturnsNull">if set to <c>true</c> [null or whitespace input returns null].</param>
        /// <returns></returns>
        private List<string> SplitCsv(string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }

        /// <summary>
        /// Gets the header value as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="headerName">Name of the header.</param>
        /// <returns></returns>
        private T GetHeaderValueAs<T>(string headerName)
        {
            StringValues values;

            if (_httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!string.IsNullOrEmpty(rawValues))
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
        #endregion
    }
}
