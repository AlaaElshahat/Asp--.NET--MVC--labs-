using Microsoft.AspNetCore.Mvc;

namespace WebApplicationlab09.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
