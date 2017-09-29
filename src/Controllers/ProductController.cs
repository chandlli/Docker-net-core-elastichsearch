using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Model;
using src.Repository;

namespace src.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        /// <summary>
        /// Search repository readonly instace
        /// </summary>
        private readonly SearchRepository<Product> searchRepository;

        /// <summary>
        /// Product controller
        /// </summary>
        /// <param name="searchRepository">Search repository injected</param>
        public ProductController(SearchRepository<Product> searchRepository)
        {
            this.searchRepository = searchRepository;
        }

        /// <summary>
        /// Search products in search repository by query
        /// </summary>
        /// <param name="query">Query to find products</param>
        /// <returns>Collection with products</returns>
        [HttpGet("search/{query}")]
        public async Task<IEnumerable<Product>> SearchProducts(string query)
        {
            var result = await searchRepository.Search(query);

            // if no results, return 404
            if (result.Count() == 0)
            {
                Response.StatusCode = 404;
            }

            return result;
        }

        /// <summary>
        /// Add products to search repository
        /// </summary>
        /// <param name="allProducts">Products</param>
        /// <returns>Action result</returns>
        [HttpPut]
        public async Task<ActionResult> Add([FromBody]List<Product> allProducts)
        {
            // add all products
            await searchRepository.Add(allProducts);

            return new JsonResult(new { message = "Success" });
        }
    }
}
