using CashDeskDemoApp.Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CashDeskDemoApp.Data.Context
{
    /// <summary>
    /// DbContext for app
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext{CashDeskDemoApp.Data.Models.ApplicationUser}" />
    public partial class CashDeskDemoAppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDeskDemoAppDbContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" />.</param>
        /// <param name="operationalStoreOptions">The <see cref="T:Microsoft.Extensions.Options.IOptions`1" />.</param>
        public CashDeskDemoAppDbContext(
           DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }
        /// <summary>
        /// Gets or sets the dashboard log history.
        /// </summary>
        /// <value>
        /// The dashboard log history.
        /// </value>
        public DbSet<DashboardLogHistory> DashboardLogHistory { get; set; }


        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}