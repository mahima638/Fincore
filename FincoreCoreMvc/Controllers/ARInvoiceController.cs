using FincoreCoreMvc.Models;
using FincoreCoreMvc.Service;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class ARInvoiceController : Controller
    {
        private readonly ARInvoiceService arinvoiceService;

        public ARInvoiceController(ARInvoiceService arinvoiceService)
        {
            this.arinvoiceService = arinvoiceService;
        }

        public async Task<IActionResult> Index3()
        {
            var data = await arinvoiceService.fetcharinvoice();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ARInvoice a)
        {
            await arinvoiceService.AddARInvoice(a);

            return RedirectToAction("Index3");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await arinvoiceService.getarinvoicebyid(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ARInvoice a)
        {
            await arinvoiceService.UpdateARInvoice(a);

            return RedirectToAction("Index3");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await arinvoiceService.deletearinvoice(id);

            return RedirectToAction("Index3");
        }
    }
}