using IntroEF.EF;
using IntroEF.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroEF.Controllers
{
    public class DepartmentController : Controller
    {
        StudentMsBSp26Context db;
        public DepartmentController(StudentMsBSp26Context db) {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Departments.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() { 
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Department d) { 
            db.Departments.Add(d); //query saved not committed
            db.SaveChanges(); //query commit returns no of rows affected
            TempData["Msg"] = d.Name +" Created Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) {
            var data = (from d in db.Departments where d.Id == id select d).SingleOrDefault();
            return View(data);
            //db.Departments.Find(id); //Search primary key
        }
    }
}
