using CartClient.Models;

namespace CartClient.Services.Models
{
    /// <summary>
    /// AuthenticationInfo
    /// </summary>
    /// <seealso cref="IAuthenticationInfo" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class AuthenticationInfo : IAuthenticationInfo
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
