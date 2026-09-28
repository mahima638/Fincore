using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AddBudgetsController : Controller
    {
        private readonly IBudgets service;

        public AddBudgetsController(IBudgets service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await service.GetAll();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetById(id);

            if (data == null)
                return NotFound();

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Budgets budget)
        {
          
            await service.Add(budget);

            return Json(new
            {
                success = true,
                message = "Budget added successfully."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(Budgets budget)
        {


            await service.Update(budget);

            return Json(new
            {
                success = true,
                message = "Budget updated successfully."
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);

            return Json(new
            {
                success = true,
                message = "Budget deleted successfully."
            });
        }
    }
}