using MassTransit;
using Sample.Common.IntegrationEvents;
using Sample.Consumer.Models;
using Sample.Infrastructure.Elastic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Consumer.Consumers
{
    public class ProductRegisteredConsumer : IConsumer<ProductRegistered>
    {
        private readonly ISyncRepository<Product> syncRepository;

        public ProductRegisteredConsumer(ISyncRepository<Product> syncRepository)
        {
            this.syncRepository = syncRepository;
        }
        public Task Consume(ConsumeContext<ProductRegistered> context)
        {
            Console.WriteLine("recieved: "+context.Message.Id);
            return syncRepository.AddAsync(new Product()
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                CategoryName= context.Message.CategoryName,
                Price = context.Message.Price
            });
        }
    }
}
