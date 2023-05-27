using Microsoft.AspNetCore.Mvc;
using WebApplicationlab09.Migrations;
using WebApplicationlab09.Models;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationlab09.Controllers
{
    public class StdController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        StudentDB DB = new StudentDB();
        UsersDB UsersDB = new UsersDB();
        Models.Users user = new Models.Users();
        public StdController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
       

        public IActionResult Index()
        {

           String userName = TempData["userName"]  as String;
            ViewBag.UserName = userName;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public  async Task<IActionResult> Create(Students std,IFormFile Image)
        {
           if (ModelState.IsValid)
            {
             
                if(Image != null&& Image.Length > 0)
                {
               
               
              
                var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                         std.Image = fileName+"";
                }
                 DB.Add(std);
                 user.Name=std.Name;
                user.Email = std.Name + "@gmail.com";
                user.Password = std.Name + "@123";
                user.Role = "std";
                UsersDB.Add(user);
                return RedirectToAction("Index", "std");

            }
                else
                    return View();
            }
            else
                return View();
        }
        [Authorize]
       public IActionResult StdList()
        {
            return View(DB.getStudents());
        }
    }
}
