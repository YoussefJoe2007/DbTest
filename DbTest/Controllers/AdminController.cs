using Microsoft.AspNetCore.Mvc;

namespace DbTest.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
    public IActionResult Check(string Email, string Password)
        {
            return View();
        }
    }
}
