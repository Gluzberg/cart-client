using System;
using System.Collections.Generic;
using System.Linq;
using CartClient.Demo.Web.Services.Models;
using System.IO;
using Newtonsoft.Json;
using CartClient.Demo.Web.Models;

namespace CartClient.Demo.Web.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ICatalogService" />
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class CatalogService : ICatalogService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogService"/> class.
        /// </summary>
        public CatalogService()
        {
            using (StreamReader r = new StreamReader(ProductsPath))
            {
                this.Products = JsonConvert
                    .DeserializeObject<IEnumerable<ProductViewModel>>(r.ReadToEnd())
                    .Aggregate(new Dictionary<Guid, IProduct>(), (d, e) => { d.Add(e.Id, e); return d; });
            }
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProduct> GetAllProducts()
        {
            return this.Products.Values;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IProduct GetProductById(Guid id)
        {
            IProduct value;

            return this.Products.TryGetValue(id, out value) ? value : null;
        }

        /// <summary>
        /// The products
        /// </summary>
        private readonly IDictionary<Guid, IProduct> Products;

        /// <summary>
        /// The products path
        /// </summary>
        private const string ProductsPath = "./wwwroot/demo-resources/products.json";
    }
}
