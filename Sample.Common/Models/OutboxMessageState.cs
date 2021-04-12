using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Common.Models
{
    public enum OutboxMessageState
    {
        ReadyToSend = 1,
        SendToQueue = 2,
        Completed = 3,
    }
}
