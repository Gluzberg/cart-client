using CartClient.Models;
using Microsoft.Extensions.Configuration;

namespace CartClient.Demo.Web.Services
{
    /// <summary>
    /// ConfigurationService
    /// </summary>
    /// <seealso cref="IConfigurationService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string this[string key] => this.Configuration[key];

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        protected IConfiguration Configuration { get; private set; }
    }
}
