using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Common.IntegrationEvents
{
    public class ProductRegistered
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
