using System.IO;
using System.Linq;
using System.Reflection;
using Bunit;
using CashDeskDemoApp.Client.Shared;
using CashDeskDemoApp.Shared.Extensions;
using CashDeskDemoApp.Shared.Models;
using Xunit;

namespace CashDeskDemoApp.UnitTests
{
    /// <summary>
    /// DashboardTest class
    /// </summary>
    /// <seealso cref="Bunit.TestContext" />
    public class DashboardTest : TestContext
    {
        /// <summary>
        /// Tests the dashboard response model is null.
        /// </summary>
        [Fact]
        public void TestDashboardResponseModelFromAPI_IsNull()
        {
            var cut = RenderComponent<DashboardView>();

            // Assert that it renders the initial loading message
            var initialExpectedHtml = @"<p><em>Loading...</em></p>";
            cut.MarkupMatches(initialExpectedHtml);
        }

        /// <summary>
        /// Tests the dashboard response model is not null.
        /// </summary>
        [Fact]
        public void TestDashboardResponseModelFromAPI_IsNotNull()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var responseViewModelJson = FileExtensions.ReadFile(string.Format("{0}\\{1}", directory, "SampleData\\dashboardApiData.json"));
            var dashboardResponseModel = responseViewModelJson.GetModelFromJsonString<DashboardResponseViewModel>();

            var cut = RenderComponent<DashboardView>(("DashboardVM", dashboardResponseModel));

            //Test location details
            Assert.Equal(cut.Find("#ip").InnerHtml, dashboardResponseModel.LocationDetails.IP);
            Assert.Equal(cut.Find("#location").InnerHtml, "From: " + dashboardResponseModel.LocationDetails.Location);

            //Test Trending Tickers
            var firstTrendingTicker = dashboardResponseModel.TrendingTickers.FirstOrDefault();

            Assert.Equal(cut.Find("#trendingTickers tbody tr:first-child td:nth-child(1)").TextContent, firstTrendingTicker.Symbol + " "+ firstTrendingTicker.Name);
            Assert.Equal(cut.Find("#trendingTickers tbody tr:first-child td:nth-child(2)").TextContent, firstTrendingTicker.MarketPrice.ToString("0.##"));
            Assert.Equal(cut.Find("#trendingTickers tbody tr:first-child td:nth-child(3)").TextContent, firstTrendingTicker.MarketChange.ToString("0.##"));
            Assert.Equal(cut.Find("#trendingTickers tbody tr:first-child td:nth-child(4)").TextContent, firstTrendingTicker.MarketChangePercent.ToString("0.##") + " %");

            //Test exchange rates
            var firstExchangeRate = dashboardResponseModel.TopExchangeRates.FirstOrDefault();
            Assert.Equal(cut.Find("#exchangeRates tbody tr:first-child td:nth-child(1)").TextContent, firstExchangeRate.Currency);
            Assert.Equal(cut.Find("#exchangeRates tbody tr:first-child td:nth-child(2)").TextContent, firstExchangeRate.LatestValue.ToString("0.####"));
            Assert.Equal(cut.Find("#exchangeRates tbody tr:first-child td:nth-child(3)").TextContent, firstExchangeRate.DiffValue.ToString("0.####"));
        }
    }
}
