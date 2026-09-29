using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService rs;
        public RoleController(IRoleService rs)
        {
            this.rs = rs;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(Role r)
        {
            if (ModelState.IsValid)
            {
                await rs.AddRole(r);
                return Json(new { mess = "Role added succesfully!" });

            }
            return View();
            
        }

        public async Task<IActionResult> GetRoles() {

            var  roles = await rs.GetRole();
            return Json(roles);
        }

        public async Task<IActionResult> DeleteRoles(int id) {

            await rs.DeleteRole(id);
            return Json(new { mess = "Role Deleted succesfully!" });
        }

        public async Task<IActionResult> EditRole(int id) {

            var rid = rs.GetRoleById(id);
            return View(rid);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(Role r)
        {
            await rs.EditRole(r);
            return View();

        }


    }
}
