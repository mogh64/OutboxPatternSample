using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public sealed class ElasticSearchClientFactory
    {
        private static ElasticClient elasticClient;
        private readonly IIndexNameStrategy indexNameStrategy;
        private static  Assembly assembly;
        public ElasticSearchClientFactory(ElasticSearchSetting setting,
                                          IIndexNameStrategy indexNameStrategy)
        {
            this.indexNameStrategy = indexNameStrategy;

            if (setting.Nodes == null)
            {
                throw new Exception("At least One Node for Elastic Search Must be specified!");
            }

            var pool = new StaticConnectionPool(setting.Nodes);
            var settings = new ConnectionSettings(pool);
            var indexList = ReadElasticIndexModels();

            AddMappings(settings, indexList);
            elasticClient = new ElasticClient(settings);

        }
        public static void RegisterAssembly(Type type)
        {
            
            if (!type.GetInterfaces().Contains(typeof(IElasticIndex)))
            {
                throw new Exception("Specified Type is not correct.It must be marked with IElasticIndex interface");
            }
            assembly = Assembly.GetAssembly(type);
        }
        public ElasticClient CreateClient()
        {            
            return elasticClient;
        }

        private Type[] ReadElasticIndexModels()
        {
            if (assembly == null)
            {
                throw new Exception("Elastic Index Assembly not registered.Please Call ElasticSearchClientFactory.RegisterAssembly in Startup by introducing an Elastic Model!");
            }
            var indexModels = assembly.GetTypes().Where(x =>
                                                        typeof(IElasticIndex).IsAssignableFrom(x) &&
                                                        x.Name != nameof(IElasticIndex)).ToArray();
            return indexModels;
        }

        private void AddMappings(ConnectionSettings connectionSettings, Type[] indexTypes)
        {
            foreach (var indexType in indexTypes)
            {
                connectionSettings.DefaultMappingFor(indexType, idx =>
                                                    idx.IndexName(indexNameStrategy.
                                                                   GetIndexName(indexType)));
            }
        }
    }
}
