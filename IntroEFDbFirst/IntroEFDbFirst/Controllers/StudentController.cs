using IntroEFDbFirst.EF;
using IntroEFDbFirst.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IntroEFDbFirst.Controllers
{
    public class StudentController : Controller
    {
        Sm26BContext db;
        public StudentController(Sm26BContext db)
        {
            this.db = db;
        }

        public IActionResult Index() { 
            var data = db.Students.Include(s=>s.Dept).ToList(); //select *
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() { 
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Student s) {
            s.Cgpa = 0;
           
            db.Students.Add(s); //insert query
            db.SaveChanges();
            return RedirectToAction("Index");
            
            
        }

        public IActionResult Details(int id) {
            //searching with PK
            var data = db.Students.Find(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id) { 
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Student formObj) { 
            var exObj = db.Students.Find(formObj.Id);

            exObj.Name = formObj.Name;
            exObj.Address = formObj.Address;
            exObj.DeptId = formObj.DeptId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) { 
            var data = db.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(string Dcsn,int Id) {
            if (Dcsn == "Yes") {
                var data = db.Students.Find(Id);
                db.Students.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Scholarship() { 
            var data = (from s in db.Students
                       where s.Cgpa>=3.75 && s.Id>=1 && s.Id <=5
                       select s).ToList();
            return View(data);
        }
      
    }
}
