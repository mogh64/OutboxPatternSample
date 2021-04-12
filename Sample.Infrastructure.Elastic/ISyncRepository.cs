using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Elastic
{
    public interface ISyncRepository<T> where T : IElasticIndex
    {
        Task BulkAsync<TInput>(IEnumerable<TInput> items) where TInput : class;
        Task AddAsync<TInput>(TInput item) where TInput : class;
    }
}
