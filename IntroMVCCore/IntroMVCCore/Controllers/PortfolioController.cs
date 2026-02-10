using IntroMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroMVCCore.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Education() {
            var test = 68;
            if (test>67) {
                return RedirectToAction("Education2");
            }
            return View();
        }
        public IActionResult Education2() {
            ViewBag.Name = "Tanvir";
            ViewBag.Id = "123";
            ViewData["Cgpa"] = 3.45f; //dictionary syntax

            EducationItem edu1 = new EducationItem();
            edu1.Title = "SSC";
            edu1.Year  = 2017;
            edu1.Result  = 4.56f;

            EducationItem edu2 = new EducationItem() { 
                Title = "HSC",
                Year = 2019,
                Result = 5.00f
            };
            EducationItem edu3 = new EducationItem()
            {
                Title = "BSc",
                Year = 2023,
                Result = 3.4f
            };

            EducationItem[] edus = new EducationItem[] { edu1, edu2,edu3 };


            return View(edus);
        }
       
       
    }
}
