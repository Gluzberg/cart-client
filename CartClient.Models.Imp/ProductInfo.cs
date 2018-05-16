using CartClient.Models;
using System;

namespace CartClient.Services.Models
{
    /// <summary>
    /// ProductInfo
    /// </summary>
    /// <seealso cref="CartClient.Models.IProductInfo" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class ProductInfo : IProductInfo
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public uint Amount { get; set; }
    }
}
