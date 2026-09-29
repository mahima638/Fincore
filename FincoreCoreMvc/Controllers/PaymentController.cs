using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FincoreCoreMvc.Controllers
{
    public class PaymentController : Controller
    {
        IPaymentService service;

        public PaymentController(IPaymentService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var pdata = await service.getPayments();

            return View(pdata);
        }

        public async Task<IActionResult> AddPayment()
        {
            var adata = await service.getAPInvoices();

            ViewBag.apinvoices = new SelectList(
                adata,
                "APInvoiceId",
                "InvoiceNumber"
            );


            var ardata = await service.getARInvoices();

            ViewBag.arinvoices = new SelectList(
                ardata,
                "ARInvoiceId",
                "InvoiceNumber"
            );


            var vdata = await service.getVendors();

            ViewBag.vendors = new SelectList(
                vdata,
                "VendorId",
                "VendorCode"
            );


            var cdata = await service.getCustomers();

            ViewBag.customers = new SelectList(
                cdata,
                "CustomerId",
                "CustomerCode"
            );


            var udata = await service.getUsers();

            ViewBag.users = new SelectList(
                udata,
                "user_id",
                "full_name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult AddPayment(Payment p)
        {
            service.AddPayment(p);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DelPayment(int id)
        {
            await service.DelPayment(id);

            return RedirectToAction("Index");
        }
    }
}