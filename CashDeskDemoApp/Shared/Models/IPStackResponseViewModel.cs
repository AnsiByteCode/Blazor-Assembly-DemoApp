using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// IP Stack Response View Model
    /// </summary>
    public class IPStackResponseViewModel
    {
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        [JsonProperty("ip")]
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the continent code.
        /// </summary>
        /// <value>
        /// The continent code.
        /// </value>
        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the continent.
        /// </summary>
        /// <value>
        /// The name of the continent.
        /// </value>
        [JsonProperty("continent_name")]
        public string ContinentName { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        /// <value>
        /// The region code.
        /// </value>
        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        /// <value>
        /// The name of the region.
        /// </value>
        [JsonProperty("region_name")]
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
