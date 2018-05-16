using System;
using Microsoft.AspNetCore.Mvc;
using CartClient.Demo.Web.Models;
using CartClient.Demo.Web.Services;

namespace CartClient.Demo.Web.ViewComponents
{
    /// <summary>
    /// CatalogViewComponent
    /// </summary>
    /// <seealso cref="ViewComponent" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CatalogViewComponent : ViewComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogViewComponent"/> class.
        /// </summary>
        /// <param name="catalogService">The catalog service.</param>
        public CatalogViewComponent(ICatalogService catalogService)
        {
            this.CatalogService = catalogService;
        }

        /// <summary>
        /// Invokes the specified cart identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public IViewComponentResult Invoke(Guid cartId)
        {
            CatalogViewModel viewModel = new CatalogViewModel()
            {
                CartId = cartId,
                Products = this.CatalogService.GetAllProducts()
            };

            return View("Index", viewModel);
        }


        /// <summary>
        /// Gets or sets the catalog service.
        /// </summary>
        /// <value>
        /// The catalog service.
        /// </value>
        protected ICatalogService CatalogService { get; set; }
    }
}
