using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AddBudgetsController : Controller
    {
        IBudgets service;

        public AddBudgetsController(IBudgets service)
        {
            this.service = service;
        }

        public IActionResult AddBudget()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBudget(Budgets b)
        {
            await service.Add(b);
            return new JsonResult("");
        }

        [HttpGet]
        public async Task<IActionResult> GetBudget(int id)
        {
            var data = await service.GetById(id);
            return new JsonResult(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBudget(Budgets b)
        {
            await service.Update(b);
            return new JsonResult("");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            await service.Delete(id);
            return new JsonResult("");
        }
    }
}