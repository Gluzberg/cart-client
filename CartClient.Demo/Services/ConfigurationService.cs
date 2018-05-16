using CartClient.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CartClient.Demo.Services
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
        public ConfigurationService()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Labels.ConfigurationFile).Build();
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

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The configuration file
            /// </summary>
            public const string ConfigurationFile = "appsettings.json";
        }
    }
}
