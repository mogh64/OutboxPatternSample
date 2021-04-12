using Microsoft.Extensions.DependencyInjection;
using Sample.Common.Interfaces;
using Sample.WorkerService.Publisher;
using Sample.WorkerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, MasstransitRabbitMessagePublisher>();
            services.AddScoped<IWorkerOutboxRepository, OutboxRepository>();

        }
    }
}
