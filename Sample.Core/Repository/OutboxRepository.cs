using Microsoft.EntityFrameworkCore;
using Sample.Common.Models;
using Sample.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Core.Repository
{
    public class OutboxRepository : IOutboxRepository
    {
        private readonly OutboxDbContext _context;

        public OutboxRepository(OutboxDbContext context)
        {
            _context = context;
        }

        public void CreateOutboxMessage(OutboxMessage outboxMessage)
        {

            _context.OutboxMessages.Add(outboxMessage);
        }

        public async Task UpdateOutboxMesageSatate(Guid eventId, OutboxMessageState state)
        {
            var outbox = await _context.OutboxMessages.FirstOrDefaultAsync(m => m.EventId == eventId);
            outbox.ChangeState(state);
        }

        public Task<List<OutboxMessage>> GetAllReadyToSend()
        {
            return _context.OutboxMessages.Where(m => m.State == OutboxMessageState.ReadyToSend).ToListAsync();
        }

        public Task SaveChange()
        {
            return _context.SaveChangesAsync();
        }

    }
}
