using Microsoft.AspNetCore.Mvc;

namespace BookWyrmCMV.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
