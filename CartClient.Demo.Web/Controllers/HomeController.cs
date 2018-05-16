using System;
using Microsoft.AspNetCore.Mvc;
using CartClient.Services;
using CartClient.Models;
using CartClient.Services.Models;
using Microsoft.AspNetCore.Http;

namespace WebProject.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    /// <seealso cref="Controller" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        public HomeController(ICartService cartService)
        {
            this.CartService = cartService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {     
            string cartIdStr = Request.Cookies[Labels.CookieName];

            Guid cartId;

            Guid.TryParse(cartIdStr, out cartId);

            if (Guid.Empty.Equals(cartId) || this.CartService.GetCartInfo(cartId) == null)
            {
                ICartInfo cart = this.CartService.CreateCart();

                if (cart != null)
                {
                    CookieOptions option = new CookieOptions();

                    option.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Append(Labels.CookieName, cart.CartId.ToString(), option);

                    return LocalRedirect(Request.Path);
                }
            }

            return View("Index", cartId);
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        public void AddProduct(Guid cartId, Guid productId)
        {
            this.CartService.AddProduct(cartId, new ProductInfo()
            {
                ProductId = productId,
                Amount = 1
            });

            this.Refresh();
        }

        /// <summary>
        /// Increases the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="amount">The amount.</param>
        public void IncreaseProduct(Guid cartId, Guid productId, uint amount)
        {
            this.CartService.EditProduct(cartId, new ProductInfo()
            {
                ProductId = productId,
                Amount = amount + 1
            });

            this.Refresh();
        }

        /// <summary>
        /// Decreases the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="amount">The amount.</param>
        public void DecreaseProduct(Guid cartId, Guid productId, uint amount)
        {
            this.CartService.EditProduct(cartId, new ProductInfo()
            {
                ProductId = productId,
                Amount = amount - 1
            });

            this.Refresh();
        }

        /// <summary>
        /// Removes the product.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="amount">The amount.</param>
        public void RemoveProduct(Guid cartId, Guid productId, uint amount)
        {
            this.CartService.RemoveProduct(cartId, productId);

            this.Refresh();
        }

        /// <summary>
        /// Clears the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        public void ClearCart(Guid cartId)
        {
            this.CartService.DeleteCart(cartId);

            this.Refresh();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        protected void Refresh()
        {
            Response.Redirect(Labels.Home);
        }

        /// <summary>
        /// Gets or sets the cart service.
        /// </summary>
        /// <value>
        /// The cart service.
        /// </value>
        protected ICartService CartService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The cookie name
            /// </summary>
            public const string CookieName = "CartClient.Demo.Web.CartId";

            /// <summary>
            /// The home
            /// </summary>
            public const string Home = "/";
        }
    }
}
