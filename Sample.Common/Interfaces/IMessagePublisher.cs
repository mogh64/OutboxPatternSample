using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Interfaces
{
    public interface IMessagePublisher
    {
        Task PublishAsync(object @event);        
    }
}
