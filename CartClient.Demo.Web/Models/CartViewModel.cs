using System;
using System.Collections.Generic;

namespace CartClient.Demo.Web.Models
{
    /// <summary>
    /// CartViewModel
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartViewModel
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The cart identifier.
        /// </value>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>
        /// The elements.
        /// </value>
        public IEnumerable<CartElementViewModel> Elements { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public float Total { get; set; }
    }
}
