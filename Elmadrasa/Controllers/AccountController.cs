using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplicationlab09.Models;

namespace WebApplicationlab09.Controllers
{
    public class AccountController : Controller
    {
        public ITIContext db;
        UsersDB usersDB=new UsersDB();
        public AccountController(ITIContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
      
            return View();
        }
         [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
           
           if (ModelState.IsValid)
            {
                var user=db.users.FirstOrDefault(a=>a.Email ==model.Email&&a.Password==model.Password);
                if(user != null)
                {
                    Claim claim1 = new Claim(ClaimTypes.Name, user.Name);
                    Claim claim2 = new Claim(ClaimTypes.Email, user.Email);
                    Claim claim3 = new Claim(ClaimTypes.Role, user.Role);
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(claim1);
                    claimsIdentity.AddClaim(claim2);
                    claimsIdentity.AddClaim(claim3);
                    ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(principal);
                    if(user.Role=="std")
                    {
                        TempData["userName"] = user.Name;
                        return RedirectToAction("index", "Std");
                    }
                        
                    
                    else
                    {
                        return RedirectToAction("index", "Admin");
                    }
                        
                   
               
            }
                else
                {
                    ModelState.AddModelError("", "Email or Password is Incorrect");
              
                    return View(model);
                   
                }

            }
            else
            {
                
                 return View(model);
            }
         
        }
        public IActionResult Createuser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Createuser(Users user)
        {
            user.Password = user.Name + "@123";
            usersDB.Add(user);

            return RedirectToAction("index", "users");
        }
    }
}
