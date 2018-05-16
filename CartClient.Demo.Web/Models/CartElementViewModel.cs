using CartClient.Demo.Web.Services.Models;

namespace CartClient.Demo.Web.Models
{
    /// <summary>
    /// CartElementViewModel
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartElementViewModel
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public IProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public uint Amount { get; set; }
    }
}
