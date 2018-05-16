using CartClient.Models;
using CartClient.Models.Imp;
using CartClient.Request.Deserializer.Imp;
using CartClient.Request.WebRequest.Imp;
using CartClient.Request.WebRequest.Parameter.Content.Imp;
using CartClient.Request.WebRequest.Parameter.Imp;
using CartClient.Services.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CartClient.Services.Internal.Imp
{
    /// <summary>
    /// TokenService
    /// </summary>
    /// <seealso cref="ITokenService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service.</param>
        public TokenService(IConfigurationService configurationService)
        {
            this.ConfigurationService = configurationService;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns>Token Info</returns>
        public IAuthenticationInfo GetToken()
        {
            if (this.AuthenticationInfo == null)
            {
                ICredentialsInfo credentials = this.GetCredentials();

                Task<AuthenticationInfo> result =
                    credentials == null ?
                    null :
                    new Request<AuthenticationInfo>().Execute(new Parameter<AuthenticationInfo>()
                    {
                        Url = this.ConfigurationService[Labels.Url],
                        Method = HttpMethod.Post,
                        Deserializer = new JsonDeserializer<AuthenticationInfo>(),
                        Content = new JsonContent(credentials)
                    });

                result.Wait();
                
                this.AuthenticationInfo = result != null  && result.IsCompleted ? result.Result : null;
            }

            return this.AuthenticationInfo;
        }


        /// <summary>
        /// Gets or sets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        protected IConfigurationService ConfigurationService { get; set; }

        /// <summary>
        /// Gets or sets the authentication information.
        /// </summary>
        /// <value>
        /// The authentication information.
        /// </value>
        protected IAuthenticationInfo AuthenticationInfo { get; set; }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <returns></returns>
        private ICredentialsInfo GetCredentials()
        {
            return new CredentialsInfo()
            {
                Username = this.ConfigurationService[Labels.Username],
                Password = this.ConfigurationService[Labels.Password]
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The URL
            /// </summary>
            public const string Url = "URLs:Token";

            /// <summary>
            /// The username
            /// </summary>
            public const string Username = "Credentials:Username";

            /// <summary>
            /// The password
            /// </summary>
            public const string Password = "Credentials:Password";
        }
    }
}
