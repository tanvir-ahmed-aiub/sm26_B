using AutoMapper;
using IntroWebAPI.EF;
using IntroWebAPI.EF.Tables;
using IntroWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        Sm26BContext db;
        public CourseController(Sm26BContext db)
        {
            this.db = db;
        }

        [HttpPost("create")]
        public IActionResult Create(CourseModel c) {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CourseModel,Course>().ReverseMap();
            });

            var mapper = new Mapper(config);
            var obj = mapper.Map<Course>(c);
            db.Courses.Add(obj);
            db.SaveChanges();
            return Ok();

        }
    }
}
