using CartClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CartClient.Services.Models
{
    /// <summary>
    /// CartInfo
    /// </summary>
    /// <seealso cref="ICartInfo" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartInfo : ICartInfo
    {
        public CartInfo()
        {
            this.ProductsRaw = new ProductInfo[0];
        }

        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public IEnumerable<IProductInfo> Products
        {
            get
            {
                return this.ProductsRaw;
            }
        }

        /// <summary>
        /// Gets or sets the products raw.
        /// </summary>
        /// <value>
        /// The products raw.
        /// </value>
        [JsonProperty("products")]
        public ProductInfo[] ProductsRaw { get; set; }
    }
}
