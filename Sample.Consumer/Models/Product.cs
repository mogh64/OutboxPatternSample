using Sample.Infrastructure.Elastic;
using System;

namespace Sample.Consumer.Models
{
    public class Product : IElasticIndex
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
