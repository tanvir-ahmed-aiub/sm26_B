using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerMVC.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service) { 
            this.service = service;
        }
        public IActionResult Index()    
        {
            var data = service.GetFullInfo();
            return View(data);
        }
    }
}
