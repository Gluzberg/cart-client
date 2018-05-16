namespace CartClient.Models
{
    /// <summary>
    /// IAuthenticationInfo
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IAuthenticationInfo
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        string Token { get; }
    }
}
