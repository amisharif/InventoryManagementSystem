using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {


        public IActionResult Index(string categoryName)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(Guid ID)
        {

            return View();

        }
    }
}
