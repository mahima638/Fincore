using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace FincoreCoreMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService us;
        private readonly IRoleService rs;
        public UserController(IUserService us)
        {
            this.us = us;
        }
        public  async Task<IActionResult> Index()
        {
            var roles = await  rs.GetRole();
            ViewBag.role = new SelectList(roles, "role_id", "role_name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User u) {
            if (ModelState.IsValid)
            {
                await us.AddUser(u);
                return Json(new { mess = "User added succesfully!" });

            }
            return View();
          }

        public async Task<IActionResult> GetUsers()
        {
            var user = await us.GetUser();
            return View(User);
        }
        public async Task<IActionResult> DeleteUser(int id)
        {

            await us.DeleteUser(id);
            return View();

        }
        public async Task<IActionResult> EditUser(int id)
        {

            var uid = await us.GetUserById(id);
            return View(uid);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(User u)
        {
            await us.EditUser(u);
            return View();

        }

    }
}
