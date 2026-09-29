using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService ds;
        public DepartmentController(IDepartmentService ds)
        {
            this.ds = ds;
        }
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department d)
        {
            if (ModelState.IsValid)
            {
                await ds.AddDepartment(d);
                return View();
            }
            return View();

        }
        public async Task<IActionResult> GetDepartment()
        {
            var d = await ds.GetDepartment();
            return View(d);
        }
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await  ds.DeleteDepartment(id);
            return View();
        }

        public async Task<IActionResult> EditDepartment(int id)
        {
           var d= await ds.GetDepartmentById(id);
            return View(d);
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department d)
        {
            await ds.EditDepartment(d);
            return View();

        }
    }
}
