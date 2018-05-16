using CartClient.Demo.Web.Services.Models;
using System;
using System.Collections.Generic;

namespace CartClient.Demo.Web.Models
{
    /// <summary>
    /// CatalogViewModel
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CatalogViewModel
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public IEnumerable<IProduct> Products { get; set; }
    }
}
