using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;
using src.Model;

namespace src.Repository
{
    /// <summary>
    /// Implementation of search repository on elasticsearch
    /// </summary>
    public class ElasticSearchRepository : SearchRepository<Product>
    {
        /// <summary>
        /// Readonly instance
        /// </summary>
        private readonly IElasticClient elasticSearchCliente;

        /// <summary>
        /// Elasticsearch repository
        /// </summary>
        /// <param name="url">Path to repository</param>
        public ElasticSearchRepository(string url)
        {
            // create a single node
            var node = new Uri(url);

            // settings
            var settings = new ConnectionSettings(node);

            // default index of this client
            settings.DefaultIndex("products");
            elasticSearchCliente = new ElasticClient(settings);
        }

        /// <summary>
        /// Add products on elastic search
        /// </summary>
        /// <param name="itens">Collection of products</param>
        /// <returns></returns>
        public async Task Add(IEnumerable<Product> itens)
        {
            var response = await elasticSearchCliente.IndexManyAsync(itens);
        }

        /// <summary>
        /// Search product on elasticsearch
        /// </summary>
        /// <param name="query">Query to serach products</param>
        /// <returns>Product collection</returns>
        public async Task<IEnumerable<Product>> Search(string query)
        {
            // return 20 results, searching by name or description and order by id asc
            var request = new SearchRequest
            {
                From = 0,
                Size = 20,
                Sort = new List<ISort>() {
                    new SortField
                    {
                        Field = "id",
                        Order = SortOrder.Ascending
                    }
                },
                Query = new MatchQuery { Field = "description", Query = query } ||
                        new MatchQuery { Field = "name", Query = query }
            };

            var response = await elasticSearchCliente.SearchAsync<Product>(request);

            // return all docs
            return response.Documents;
        }
    }
}