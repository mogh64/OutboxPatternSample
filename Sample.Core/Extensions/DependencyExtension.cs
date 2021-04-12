using Microsoft.Extensions.DependencyInjection;
using Sample.Common.Interfaces;
using Sample.Core.Publisher;
using Sample.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Core.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {            
            AddRepositories(services);    
            AddOutbox(services);
        }
        

        private static void AddOutbox(IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, OutboxPublisher>();
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IOutboxRepository, OutboxRepository>();

        }
    }
}
