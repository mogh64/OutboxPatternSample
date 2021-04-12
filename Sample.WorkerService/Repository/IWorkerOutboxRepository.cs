using Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService.Repository
{
    public interface IWorkerOutboxRepository
    {
        Task<List<OutboxMessage>> GetReadyToSendMessages();
        Task SaveAsync();
    }
}
