using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using src.Model;
using src.Repository;

namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            ConfigureRepository(services);
        }

        /// <summary>
        /// Configure injected repositories
        /// </summary>
        /// <param name="services">Service collection</param>
        private void ConfigureRepository(IServiceCollection services)
        {
            // Elasticsearch repository to search
            var elasticSearchRepository = new ElasticSearchRepository(Configuration.GetSection("DataSources:ElasticSearch:ConnectionString").Value);

            services.AddSingleton<SearchRepository<Product>>(elasticSearchRepository);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
