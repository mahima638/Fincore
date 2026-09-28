using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel lg)
        {
            if(lg.email.Equals("Admin@gmail.com") && lg.pass.Equals("123"))
            {

                return RedirectToAction("admin", "dashboard");
            }
            return View();


        }

        
    }
}


