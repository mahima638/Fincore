using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FincoreCoreMvc.Controllers
{
    public class APInvoiceController : Controller
    {
        IAPInvoiceService service;

        public APInvoiceController(IAPInvoiceService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var adata = await service.getAPInvoices();

            return View(adata);
        }

        public async Task<IActionResult> AddAPInvoice()
        {
            var vdata = await service.getVendors();
            ViewBag.vendors = new SelectList(vdata, "VendorId", "VendorCode");

            var pdata = await service.getPurchaseOrders();
            ViewBag.purchaseorders = new SelectList(pdata, "POId", "POCode");

            var udata = await service.getUsers();
            ViewBag.users = new SelectList(udata, "user_id", "full_name");

            return View();
        }

        [HttpPost]
        public IActionResult AddAPInvoice(APInvoice a)
        {
            service.AddAPInvoice(a);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DelAPInvoice(int id)
        {
            await service.DelAPInvoice(id);

            return RedirectToAction("Index");
        }
    }
}