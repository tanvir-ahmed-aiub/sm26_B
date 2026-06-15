using Microsoft.AspNetCore.Mvc;

namespace IntroMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Login() { 
            return  View();
        }
        public IActionResult SignUp() {
            return View();
        }
        public IActionResult List() {
            return View();
        }
        public IActionResult Details() {
            return View();
        }
    }
}
