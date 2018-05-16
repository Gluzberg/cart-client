namespace CartClient.Models
{
    /// <summary>
    /// ICredentialsInfo
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICredentialsInfo
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        string Username { get; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; }
    }
}
