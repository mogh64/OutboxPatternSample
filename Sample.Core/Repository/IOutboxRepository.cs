using Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Core.Repository
{
    public interface IOutboxRepository
    {
        void CreateOutboxMessage(OutboxMessage outboxMessage);
        Task UpdateOutboxMesageSatate(Guid eventId, OutboxMessageState state);
        Task<List<OutboxMessage>> GetAllReadyToSend();
        Task SaveChange();
    }
}
