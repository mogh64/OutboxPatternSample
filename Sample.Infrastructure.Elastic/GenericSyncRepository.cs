using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Elastic
{
    public class GenericSyncRepository<TDocument> : ISyncRepository<TDocument> where TDocument : IElasticIndex
    {

        ElasticClient client;

        public GenericSyncRepository(ElasticSearchClientFactory clientFactory)
        {
            client = clientFactory.CreateClient();
        }

        public ElasticClient Client => client;

        public async Task AddAsync<TInput>(TInput item) where TInput : class
        {
            var indexResponse = await client.IndexAsync(item, i => i.Index(typeof(TDocument)));
            if (!indexResponse.IsValid)
            {

                throw new Exception("ElasticSearch Fialed To Write!");
            }
        }

        public async Task BulkAsync<TInput>(IEnumerable<TInput> items) where TInput : class
        {
            var asyncBulkIndexResponse = await client.BulkAsync(b => b
                 .Index(typeof(TDocument))
                 .IndexMany(items)
                 );

            if (asyncBulkIndexResponse.Errors)
            {

                throw new Exception("ElasticSearch Fialed To Write!");
            }
        }       
    }
}
