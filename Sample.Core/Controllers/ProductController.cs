using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Common.IntegrationEvents;
using Sample.Common.Models;
using Sample.Core.Dto;
using Sample.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IOutboxRepository outboxRepository;

        public ProductController(IOutboxRepository outboxRepository)
        {
            this.outboxRepository = outboxRepository;
        }
        [HttpPost]
        public Task CreateNew([FromBody] ProductDto productDto)
        {
            //Suppose that you have registered new Product in Relational database such as MSSQL Server
            //After completion you have to raise ProductRegistered Event to Outbox
            var @event = new ProductRegistered()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                CategoryName= productDto.CategoryName,
                Price = productDto.Price
            };
            outboxRepository.CreateOutboxMessage(new OutboxMessage(@event, Guid.NewGuid(), DateTime.Now));
            return outboxRepository.SaveChange();
        }
    }
}
