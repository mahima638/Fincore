using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPOService service;

        public PurchaseOrderController(IPOService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await service.GetPurchaseOrdersAsync();
            return View(orders);
        }
        public async Task<IActionResult> Details(int id)
        {
            var po = await service.GetPurchaseOrderByIdAsync(id);
            if (po == null) return NotFound();
            return View(po);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.NextPOCode = await service.GeneratePOCodeAsync();
            return View(new PurchaseOrder());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrder po)
        {
            if (po.Items != null && po.Items.Count > 0)
            {
                await service.AddPurchaseOrderAsync(po);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "add at least 1 line item to the purchase order");
            ViewBag.NextPOCode = await service.GeneratePOCodeAsync();
            return View(po);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var po = await service.GetPurchaseOrderByIdAsync(id);
            if (po == null) return NotFound();

            if (po.Status != "Draft" && po.Status != "Rejected")
            {
                TempData["Error"] = "only draft or rejected purchase orders can be edited";
                return RedirectToAction(nameof(Index));
            }

            return View(po);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseOrder po, int id)
        {
            await service.EditPurchaseOrderAsync(po, id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeletePurchaseOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await service.UpdateStatusAsync(id, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
