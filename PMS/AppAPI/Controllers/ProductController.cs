using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService service;
        public ProductController(ProductService service) { 
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult ALl() {
            var data = service.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(ProductModel p)
        {
            var data = service.Create(p);
            return Ok(data);
        }
        [HttpPut("update")]
        public IActionResult Update(ProductModel p)
        {
            var data = service.Update(p);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }
    }
}
