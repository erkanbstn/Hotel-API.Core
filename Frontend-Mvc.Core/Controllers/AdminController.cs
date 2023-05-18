using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
