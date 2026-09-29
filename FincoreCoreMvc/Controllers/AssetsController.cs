using FincoreCoreMvc.Models;
using FincoreCoreMvc.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssets assetService;

        public AssetsController(IAssets assetService)
        {
            this.assetService = assetService;
        }

        
        public async Task<IActionResult> Index1()
        {
            var data = await assetService.FetchAssets();

            return View(data);
        }

        
        [HttpGet]
        public IActionResult RegisterAsset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsset(Assets a)
        {
            await assetService.AddAsset(a);

            return RedirectToAction("Index1");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsset(int id)
        {
            var data = await assetService.GetAssetById(id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsset(Assets a)
        {
            a.ModifiedAt = DateTime.Now;

            await assetService.UpdateAsset(a);

            return RedirectToAction("Index1");
        }
    }
}