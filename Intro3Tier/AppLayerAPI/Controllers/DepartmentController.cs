using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service) { 
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult ALl() {
            var data = service.All() ; //call to BLL
            return Ok(data);
        }

        [HttpGet("all/info")]
        public IActionResult AllInfo() { 
            var data = service.GetFullInfo() ; ;
            return Ok(data);
        }
    }
}
