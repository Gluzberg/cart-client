using CartClient.Demo.Web.Services.Models;
using System;
using System.Collections.Generic;

namespace CartClient.Demo.Web.Services
{
    /// <summary>
    /// ICatalogService
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface ICatalogService
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProduct> GetAllProducts();

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IProduct GetProductById(Guid id);
    }
}
