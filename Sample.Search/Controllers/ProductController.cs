using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Infrastructure.Elastic;
using Sample.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IReadRepository<Product> readRepository;

        public ProductController(IReadRepository<Product> readRepository)
        {
            this.readRepository = readRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]string search)
        {
           var response = await readRepository.PrefixSearchAsync(x => x.Name, search);

           return Ok(response.Documents.ToList());
        }
    }
}
