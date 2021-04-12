using Nest;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Elastic
{
    public class GenericReadRepository<TDocument> : IReadRepository<TDocument> where TDocument : class, IElasticIndex
    {
        private readonly ElasticClient client;
        public GenericReadRepository(ElasticSearchClientFactory clientFactory)
        {
            client = clientFactory.CreateClient();
        }
        public Task<ISearchResponse<TDocument>> PrefixSearchAsync(Expression<Func<TDocument, object>> matchPrefixExpression, string search)
        {
            var queryContainer = new QueryContainerDescriptor<TDocument>();

            queryContainer.Prefix(t => t
           .Field(matchPrefixExpression.KeywordSuffix()).Value(search));

            var searchDescriptor = new SearchDescriptor<TDocument>();            
            searchDescriptor = searchDescriptor.Query(q => q.Bool(b => b.Should(queryContainer)));

            return  client.SearchAsync<TDocument>(searchDescriptor);            
        }
    }
}
