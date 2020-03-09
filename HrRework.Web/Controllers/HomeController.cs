using Microsoft.AspNetCore.Mvc;

namespace HrRework.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
