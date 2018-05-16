namespace CartClient.Models.Imp
{
    /// <summary>
    /// #credentialsInfo
    /// </summary>
    /// <seealso cref="ICredentialsInfo" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CredentialsInfo : ICredentialsInfo
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
}
