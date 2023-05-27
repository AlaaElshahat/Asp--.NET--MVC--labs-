using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplicationlab09.Models;

namespace WebApplicationlab09.Controllers
{
    public class UsersController : Controller
    {
        ITIContext itIContext = new ITIContext();
        [Authorize]
        public IActionResult Index()
        {
            return View(itIContext.users.ToList());
        }
    }
}
