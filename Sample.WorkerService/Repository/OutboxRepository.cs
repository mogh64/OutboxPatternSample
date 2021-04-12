using Microsoft.EntityFrameworkCore;
using Sample.Common.Models;
using Sample.WorkerService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService.Repository
{
    public class OutboxRepository : IWorkerOutboxRepository
    {
        private readonly OutboxDbContext dbContext;

        public OutboxRepository(OutboxDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<OutboxMessage>> GetReadyToSendMessages()
        {
            return dbContext.OutboxMessages.Where(x => x.State == OutboxMessageState.ReadyToSend).ToListAsync();
        }
        public Task SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
