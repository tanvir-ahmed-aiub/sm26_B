using Microsoft.AspNetCore.Mvc;

namespace MVCBasics.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string name, int cid)
        {
            ViewBag.Name = name;
            ViewBag.Id  = cid;
            return View();
        }
    }
}
