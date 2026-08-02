using IntroWebAPI.EF;
using IntroWebAPI.EF.Tables;
using IntroWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Sm26BContext db;
        public StudentController(Sm26BContext db) { 
            this.db = db;
        }
        [HttpGet]
        public IActionResult All() { 
            var data = db.Students.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var data = db.Students.Find(id);
            return Ok(data);
        }

        [HttpGet("scholarship")]
        public IActionResult FilterSch() { 
            var data = (from s in db.Students
                       where s.Cgpa>=3.75
                       select s).ToList();
            return Ok(data);
        }
        [HttpGet("probation")]
        public IActionResult FilterProbation()
        {
            var data = (from s in db.Students
                        where s.Cgpa < 2.50
                        select s).ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(StudentModel s) {
            //validation
            var obj = new Student() { 
                Name = s.Name,
                Address = s.Address,
                Cgpa = s.Cgpa,
                DeptId = s.DeptId,
            };
            db.Students.Add(obj);
            db.SaveChanges();
            return Ok();
        }
    }
}
