using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class CourseController : Controller
    {
        

        public IActionResult Index()
        {
            Course[] courses = new Course[10];
            for (int i = 1; i <= 10; i++)
            {
                courses[i - 1] = new Course()
                {
                    Id = i,
                    Name = "Course " + i
                };
            }
            return View(courses);
        }
        public IActionResult Details(int id) {
            var c = new Course() { 
                Id= id,
                Name = "Course "+id
            };
            return View(c);
        }
    }
}
