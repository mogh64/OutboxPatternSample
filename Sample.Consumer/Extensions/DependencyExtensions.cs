using Microsoft.Extensions.DependencyInjection;
using Sample.Infrastructure.Elastic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Consumer.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            AddElastic(services);
            services.AddScoped(typeof(ISyncRepository<>), typeof(GenericSyncRepository<>));           
        }
        private static void AddElastic(IServiceCollection services)
        {
            services.AddSingleton<ElasticSearchSetting>();
            services.AddSingleton<ElasticSearchClientFactory>();
            services.AddSingleton<IIndexNameStrategy, KebabCaseIndexNamingStrategy>();
        }
    }
}
