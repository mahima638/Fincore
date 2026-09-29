using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService service;
        public AccountController(IAuthService service)
        {
            this.service = service;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lg)
        {

            if (!ModelState.IsValid)
            {
                return View(lg);
            }
            var user = service.Login(lg.email, lg.pass);
            if (user == null)
            {

                ViewBag.Error = "Invalid email or password!";
                return View(lg);
            }
            HttpContext.Session.SetInt32("UserId", user.user_id);
            HttpContext.Session.SetString("UserName", user.full_name);
            HttpContext.Session.SetString("RoleName", user.role.role_name);
            return RedirectToAction("Dashboard");


        }


        
    }
}


