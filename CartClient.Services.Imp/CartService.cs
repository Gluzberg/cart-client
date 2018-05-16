using System;
using CartClient.Models;
using CartClient.Request.WebRequest.Imp;
using CartClient.Request.WebRequest.Parameter.Imp;
using System.Net.Http;
using CartClient.Request.Deserializer.Imp;
using System.Threading.Tasks;
using CartClient.Request.WebRequest.Parameter.Content.Imp;
using CartClient.Services.Internal;
using CartClient.Request.WebRequest.Parameter.Header.Imp;
using System.Collections.Specialized;
using CartClient.Services.Models;

namespace CartClient.Services
{
    /// <summary>
    /// CartService
    /// </summary>
    /// <seealso cref="ICartService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartService : ICartService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service.</param>
        /// <param name="tokenService">The token service.</param>
        public CartService(IConfigurationService configurationService, ITokenService tokenService)
        {
            this.ConfigurationService = configurationService;
            this.TokenService = tokenService;
        }

        /// <summary>
        /// Creates the cart.
        /// </summary>
        /// <param name="cartID">The cart identifier.</param>
        /// <returns>
        /// Created cart with the coresponding ID if specified, otherwise the cart is created with a random ID
        /// </returns>
        public ICartInfo CreateCart(Guid? cartID = null)
        {
            return this.Request<CartInfo>(HttpMethod.Post, cartID.HasValue ? cartID.Value : Guid.NewGuid());
        }

        /// <summary>
        /// Gets the cart information.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>
        /// Get the cart with the corresponding ID if such exists, null otherwise
        /// </returns>
        public ICartInfo GetCartInfo(Guid cartId)
        {
            return this.Request<CartInfo>(HttpMethod.Get, cartId);
        }

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>
        /// True if deleting was successful, false otherwise
        /// </returns>
        public bool DeleteCart(Guid cartId)
        {
            return this.Request<CartInfo>(HttpMethod.Delete, cartId) != null;
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>
        /// The added cart
        /// </returns>
        public bool AddProduct(Guid cartId, IProductInfo product)
        {
            ICartInfo cart = new CartInfo()
            {
                CartId = cartId,
                ProductsRaw = new ProductInfo[] { product as ProductInfo }
            };

            return this.Request<CartInfo>(HttpMethod.Put, null, cart) != null;
        }

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>
        /// The modified cart
        /// </returns>
        public bool EditProduct(Guid cartId, IProductInfo product)
        {
            ICartInfo cart = new CartInfo()
            {
                CartId = cartId,
                ProductsRaw = new ProductInfo[] { product as ProductInfo }
            };

            return this.Request<CartInfo>(HttpMethod.Put, null, cart) != null;
        }

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// True if remocing of the product was successful, false otherwise
        /// </returns>
        public bool RemoveProduct(Guid cartId, Guid productId)
        {
            ICartInfo cart = new CartInfo()
            {
                CartId = cartId,
                ProductsRaw = new ProductInfo[] { new ProductInfo() { ProductId = productId, Amount = 0 } }
            };

            return this.Request<CartInfo>(HttpMethod.Put, null, cart) != null;
        }

        #region Non-Public Methods

        /// <summary>
        /// Requests the specified method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="content">The content.</param>
        /// <returns>Request result</returns>
        protected T Request<T>(HttpMethod method, Guid? id, ICartInfo content = null) where T : class
        {
            IAuthenticationInfo authenticationInfo;

            if ((authenticationInfo = this.TokenService.GetToken()) == null || authenticationInfo.Token == null)
            {
                return null;
            }

            Task<T> result = new Request<T>().Execute(new Parameter<T>()
            {
                Url = string.Format(this.ConfigurationService[Labels.Url], id.HasValue ? id.Value.ToString() : string.Empty),
                Method = method,
                Deserializer = new JsonDeserializer<T>(),
                Content = content != null ? new JsonContent(content) : null,
                Header = new Header(new NameValueCollection { { Labels.Authorization, string.Format(Labels.Bearer, authenticationInfo.Token) } })
            });

            result.Wait();

            return result.Result;
        }

        /// <summary>
        /// Gets or sets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        protected IConfigurationService ConfigurationService { get; set; }

        /// <summary>
        /// Gets the token service.
        /// </summary>
        /// <value>
        /// The token service.
        /// </value>
        protected ITokenService TokenService { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The URL
            /// </summary>
            public const string Url = "URLs:Cart";

            /// <summary>
            /// The authorization
            /// </summary>
            public const string Authorization = "Authorization";

            /// <summary>
            /// The bearer
            /// </summary>
            public const string Bearer = "Bearer {0}";
        }

        #endregion
    }
}
