using CartClient.Models;
using System;

namespace CartClient.Services
{
    /// <summary>
    /// ICartService
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICartService
    {
        /// <summary>
        /// Creates the cart.
        /// </summary>
        /// <param name="cartID">The cart identifier.</param>
        /// <returns>Created cart with the coresponding ID if specified, otherwise the cart is created with a random ID</returns>
        ICartInfo CreateCart(Guid? cartID = null);

        /// <summary>
        /// Gets the cart information.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>Get the cart with the corresponding ID if such exists, null otherwise</returns>
        ICartInfo GetCartInfo(Guid cartId);

        /// <summary>
        /// Deletes the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns>True if deleting was successful, false otherwise</returns>
        bool DeleteCart(Guid cartId);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>The added cart</returns>
        bool AddProduct(Guid cartId, IProductInfo product);

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>The modified cart</returns>
        bool EditProduct(Guid cartId, IProductInfo product);

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>True if remocing of the product was successful, false otherwise</returns>
        bool RemoveProduct(Guid cartId, Guid productId);
    }
}
