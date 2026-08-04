using AutoMapper;
using IntroAPiwithMapping.EF;
using IntroAPiwithMapping.EF.Tables;
using IntroAPiwithMapping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroAPiwithMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        Sm26BContext db;
        IMapper mapper;
        public DepartmentController(Sm26BContext db,IMapper mapper) { 
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create(DepartmentModel dd) {
            var mapped = mapper.Map<Department>(dd);
            db.Departments.Add(mapped);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult Get() { 
            var data = db.Departments.ToList();
            var mapped = mapper.Map<List<DepartmentModel>>(data);
            return Ok(mapped);    
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var data = db.Departments.Find(id);
            var mapped = mapper.Map<DepartmentModel>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}/students")]
        public IActionResult GetwithStudents(int id) { 
            var dept = (from d in db.Departments.Include(d=>d.Students)
                       where d.Id == id
                       select d).SingleOrDefault();
            var mapped = mapper.Map<DepartmentStudentModel>(dept);
            return Ok(mapped);

        }
        [HttpGet("{id}/courses")]
        public IActionResult DeptwithCourse(int id) {
            var dept = (from d in db.Departments.Include(d => d.Courses)
                        where d.Id == id
                        select d).SingleOrDefault();
            var mapped = mapper.Map<DepartmentCourseModel>(dept);
            return Ok(mapped);
        }

        [HttpGet("{id}/info")]
        public IActionResult DeptInfo(int id) { 
            var data = (from d in db.Departments.Include(d=>d.Students)
                       .Include(d=>d.Courses)
                       where d.Id == id
                       select d).SingleOrDefault();
            var mapped = mapper.Map<DepartmentInfoModel>(data);
            return Ok(mapped);
        }
        [HttpGet("all/info")]
        public IActionResult AllInfo() {
            var data = db.Departments.Include(d=>d.Students)
                .Include(d=>d.Courses).ToList();
            var mapped = mapper.Map<List<DepartmentInfoModel>>(data);
            return Ok(mapped);
        }
    }
}
