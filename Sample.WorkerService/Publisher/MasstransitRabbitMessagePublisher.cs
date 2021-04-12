using MassTransit;
using Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService.Publisher
{
    public class MasstransitRabbitMessagePublisher : IMessagePublisher
    {
        private readonly IPublishEndpoint publisher;

        public MasstransitRabbitMessagePublisher(IPublishEndpoint publisher)
        {
            this.publisher = publisher;
        }
        

        public Task PublishAsync(object @event)
        {
            return publisher.Publish(@event);
        }
    }
}
