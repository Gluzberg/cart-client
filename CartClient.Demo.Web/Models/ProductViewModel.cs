using CartClient.Demo.Web.Services.Models;
using System;

namespace CartClient.Demo.Web.Models
{
    /// <summary>
    /// ProductViewModel
    /// </summary>
    /// <seealso cref="IProduct" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class ProductViewModel : IProduct
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public float Price { get; set; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }
    }
}
