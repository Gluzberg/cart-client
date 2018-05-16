using System;

namespace CartClient.Models
{
    /// <summary>
    /// IProductInfo
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IProductInfo
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        Guid ProductId { get; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        uint Amount { get; }
    }
}
