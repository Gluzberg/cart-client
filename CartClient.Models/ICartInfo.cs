using System;
using System.Collections.Generic;

namespace CartClient.Models
{
    /// <summary>
    /// ICartInfo
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartInfo
    {
        /// <summary>
        /// Gets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        Guid CartId { get; }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        IEnumerable<IProductInfo> Products { get; }
    }
}
