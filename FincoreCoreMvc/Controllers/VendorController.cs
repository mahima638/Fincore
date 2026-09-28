using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FincoreCoreMvc.Controllers
{
    public class VendorController : Controller
    {
        IVendorService vendorService;

        public VendorController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }

        public async Task<IActionResult> Index()
        {
            var i = await vendorService.GetVendor();
            return View(i);
        }

        [HttpGet]
        public async Task<IActionResult> AddVendor()
        {
            var v = await vendorService.GetCompany();
            ViewBag.Company = new SelectList(v, "company_id", "company_name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddVendor(Vendor ven)
        {
            ven.CreatedBy = 1;
            ven.ModifiedBy = 1;
            await vendorService.AddVendor(ven);
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> DelVendor(int id)
        {
            await vendorService.DelVendor(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdVendor(int id)
        {
            var upd = await vendorService.FindVendorById(id);

            var c = await vendorService.GetCompany();

            ViewBag.Company = new SelectList(
                c,
                "company_id",
                "company_name",
                upd.company_id
            );

            return View(upd);
        }



        [HttpPost]
        public async Task<IActionResult> UpdVendor(Vendor vnd)
        {
            vnd.ModifiedBy = 1;
            vnd.ModifiedAt = DateTime.Now;
            await vendorService.UpdVendor(vnd);
            return RedirectToAction("Index");
        }
    }
}
