using FincoreCoreMvc.Models;
using FincoreCoreMvc.Service;
using Microsoft.AspNetCore.Mvc;


namespace FincoreCoreMvc.Controllers
{
    public class RevenueController : Controller
    {
        private readonly RevenueServices revenueService;

        public RevenueController(RevenueServices revenueService)
        {
            this.revenueService = revenueService;
        }

        public async Task<IActionResult> Index2()
        {
            var data = await revenueService.fetchrevenue();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Customer = await revenueService.fetchcustomer();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RevenueEntry r)
        {
            await revenueService.AddRevenue(r);
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await revenueService.GetRevenueById(id);

            if (data == null)
            {
                return NotFound();
            }

            ViewBag.Customer = await revenueService.fetchcustomer();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RevenueEntry r)
        {
            await revenueService.UpdateRevenue(r);

            return RedirectToAction("Index2");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await revenueService.deleterevenue(id);

            return RedirectToAction("Index2");
        }
    }
}