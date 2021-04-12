using Nest;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Elastic
{
    public interface IReadRepository<TDocument> where TDocument : class, IElasticIndex
    {
        Task<ISearchResponse<TDocument>> PrefixSearchAsync
           (Expression<Func<TDocument, object>> matchPrefixExpression,
           string search);
    }
}
