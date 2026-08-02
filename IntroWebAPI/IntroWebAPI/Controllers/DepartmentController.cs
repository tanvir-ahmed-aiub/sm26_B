using IntroWebAPI.EF;
using IntroWebAPI.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        Sm26BContext db;
        public DepartmentController(Sm26BContext db) { 
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get() { 
            var data = db.Departments.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(Department d) {
            db.Departments.Add(d);
            db.SaveChanges();
            return Created();
        }

    }
}
