using AutoMapper;
using IntroAPiwithMapping.EF;
using IntroAPiwithMapping.EF.Tables;
using IntroAPiwithMapping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace IntroAPiwithMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Sm26BContext db;
        IMapper mapper;
        public StudentController(Sm26BContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpPost("create")]
        public IActionResult Create(StudentModel s) {
            var mapped = mapper.Map<Student>(s);
            db.Students.Add(mapped);
            db.SaveChanges();
            return Ok(mapped);

        }
        [HttpGet]
        public IActionResult Get() {
            var data = db.Students.ToList();
            var mapped = mapper.Map<List<StudentModel>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var data = db.Students.Find(id);
            var mapped = mapper.Map<StudentModel>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}/info")]
        public IActionResult GetwithDept(int id) { 
            var data = (from s in db.Students.Include(s=>s.Dept)
                       where s.Id == id
                       select s).SingleOrDefault();
            var mapped = mapper.Map<StudentInfoModel>(data);
            return Ok(mapped);
        }
    }
}
