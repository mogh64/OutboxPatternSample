using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Common.Models
{
    public class OutboxMessage
    {
        protected OutboxMessage()
        {

        }

        public OutboxMessage(object message, Guid eventId, DateTime eventDate)
        {
            Data = JsonConvert.SerializeObject(message);
            Type = message.GetType().FullName + ", " +
                   message.GetType().Assembly.GetName().Name;
            EventId = eventId;
            EventDate = eventDate;
            State = OutboxMessageState.ReadyToSend;
            ModifiedDate = DateTime.Now;
        }

        public long Id { get; protected set; }
        public string Data { get; protected set; }
        public string Type { get; protected set; }
        public Guid EventId { get; protected set; }
        public DateTime EventDate { get; protected set; }
        public OutboxMessageState State { get; private set; }
        public DateTime ModifiedDate { get; set; }

        public void ChangeState(OutboxMessageState state)
        {
            State = state;
            this.ModifiedDate = DateTime.Now;
        }

        public object RecreateMessage() =>
                JsonConvert.DeserializeObject(Data, System.Type.GetType(Type));
    }
}
