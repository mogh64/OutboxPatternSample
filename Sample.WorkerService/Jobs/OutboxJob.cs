using Microsoft.Extensions.Logging;
using Quartz;
using Sample.Common.Interfaces;
using Sample.Common.Models;
using Sample.WorkerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService.Jobs
{
    [DisallowConcurrentExecution]
    public class OutboxJob : IJob
    {
        private readonly ILogger<OutboxJob> logger;
        private readonly IWorkerOutboxRepository repository;
        private readonly IMessagePublisher messagePublisher;

        public OutboxJob(ILogger<OutboxJob> logger,
                         IWorkerOutboxRepository repository,
                         IMessagePublisher messagePublisher)
        {
            this.logger = logger;
            this.repository = repository;
            this.messagePublisher = messagePublisher;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var readyToSendItems = await repository.GetReadyToSendMessages();
            logger.LogInformation($"Outbox count {readyToSendItems.Count}:date : {DateTime.Now.ToLongTimeString()}");

            foreach (var item in readyToSendItems)
            {
                var eventMessage = item.RecreateMessage();
                await messagePublisher.PublishAsync(eventMessage);
                item.ChangeState(OutboxMessageState.SendToQueue);
            }

            await repository.SaveAsync();

        }
    }
}
