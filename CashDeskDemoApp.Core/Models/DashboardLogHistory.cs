using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashDeskDemoApp.Data.Models
{
    /// <summary>
    /// Dashboard Log History
    /// </summary>
    [Table("DashboardLogHistory")]
    public class DashboardLogHistory
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        public string IP { get; set; }
        /// <summary>
        /// Gets or sets the name of the continent.
        /// </summary>
        /// <value>
        /// The name of the continent.
        /// </value>
        public string ContinentName { get; set; }
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName { get; set; }
        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        /// <value>
        /// The name of the city.
        /// </value>
        public string CityName { get; set; }
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        /// <value>
        /// The application user.
        /// </value>
        public ApplicationUser AppUser { get; set; }
        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; set; }
    }
}
