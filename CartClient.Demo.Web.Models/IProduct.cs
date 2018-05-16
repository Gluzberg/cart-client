using System;

namespace CartClient.Demo.Web.Services.Models
{
    /// <summary>
    /// IProduct
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IProduct
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        float Price { get; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        string Image { get; }
    }
}
