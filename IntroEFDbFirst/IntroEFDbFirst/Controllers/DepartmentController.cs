using IntroEFDbFirst.EF;
using IntroEFDbFirst.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroEFDbFirst.Controllers
{
    public class DepartmentController : Controller
    {
        

        Sm26BContext db = new Sm26BContext();
        public IActionResult Index()
        {
            var data = db.Departments.ToList();//select query
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department d) { 
            if(ModelState.IsValid) {
                db.Departments.Add(d); //insert query
                db.SaveChanges(); //executes the query
            }
            return View();
        }
    }
}
