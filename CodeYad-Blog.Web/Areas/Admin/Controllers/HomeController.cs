using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
