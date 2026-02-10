using IntroMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroMVCCore.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new Random();
            
            List<Student> data = new List<Student>();
            for (int i = 1; i <= 10; i++) {
                data.Add(new Student() { 
                    Id = i,
                    Name ="Student " + i.ToString(),
                    Cgpa = (float)(rnd.Next(2,4) + rnd.NextDouble())
                });
            }
            return View(data);
        }
        public IActionResult Details(int id) { 
            Student student = new Student();
            student.Id = id;
            student.Name = "Student " + id;
            student.Cgpa = 3.45f;
            return View(student);
        }
        public IActionResult Edit() { 
            return View();
        }
    }
}
