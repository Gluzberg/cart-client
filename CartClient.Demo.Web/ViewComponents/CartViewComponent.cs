using CartClient.Demo.Web.Models;
using CartClient.Demo.Web.Services;
using CartClient.Models;
using CartClient.Services;
using CartClient.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CartClient.Demo.Web.ViewComponents
{
    /// <summary>
    /// CartViewComponent
    /// </summary>
    /// <seealso cref="ViewComponent" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CartViewComponent : ViewComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartViewComponent"/> class.
        /// </summary>
        /// <param name="catalogService">The catalog service.</param>
        /// <param name="cartService">The cart service.</param>
        public CartViewComponent(ICatalogService catalogService, ICartService cartService)
        {
            this.CatalogService = catalogService;
            this.CartService = cartService;
        }

        /// <summary>
        /// Invokes the specified cart identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public IViewComponentResult Invoke(Guid cartId)
        {
            ICartInfo cartInfo = this.CartService.GetCartInfo(cartId) ?? new CartInfo();

            CartViewModel cart = new CartViewModel()
            {
                CartId = cartId,
                Elements = cartInfo.Products.Select(m =>
                    new CartElementViewModel()
                    {
                        Product = this.CatalogService.GetProductById(m.ProductId),
                        Amount = m.Amount
                    })
            };

            cart.Total = cart.Elements.Aggregate((float)0, (t, e) => t + e.Amount * e.Product.Price);

            return View("Index", cart);
           
        }

        /// <summary>
        /// Gets or sets the cart service.
        /// </summary>
        /// <value>
        /// The cart service.
        /// </value>
        protected ICartService CartService { get; set; }

        /// <summary>
        /// Gets or sets the catalog service.
        /// </summary>
        /// <value>
        /// The catalog service.
        /// </value>
        protected ICatalogService CatalogService { get; set; }
    }
}
