using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService service;
        public OrderController(OrderService service) { 
            this.service = service; 
        }
        [HttpPost("place")]
        public IActionResult PlaceOrder(OrderPlaceModel model) {
            var data = service.PlaceOrder(model);
            return Ok(data);
        }
    }
}
