using Microsoft.AspNetCore.Mvc;

namespace FincoreCoreMvc.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
