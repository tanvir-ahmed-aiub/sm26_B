using IntroDTO.DTOs;
using IntroDTO.EF;
using IntroDTO.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroDTO.Controllers
{
    public class StudentController : Controller
    {
        StudentMsBSp26Context db;
        public StudentController(StudentMsBSp26Context db) { 
            this.db = db;
        }
        [HttpGet]
        public IActionResult Create() { 
            //wihout DTO
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View();  
        }
        public IActionResult Create(StudentDTO s) {
            if (ModelState.IsValid) {
                var st = new Student() { 
                    Name = s.Name,
                    DeptId = s.DeptId
                };
                db.Students.Add(st);    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
