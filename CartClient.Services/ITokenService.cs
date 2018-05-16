using CartClient.Models;

namespace CartClient.Services.Internal
{
    /// <summary>
    /// ITokenService
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ITokenService
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns></returns>
        IAuthenticationInfo GetToken();
    }
}
