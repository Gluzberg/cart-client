namespace CartClient.Models
{
    /// <summary>
    /// IConfigurationService
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the <see cref="String"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="String"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string this[string key] { get; }
    }
}
