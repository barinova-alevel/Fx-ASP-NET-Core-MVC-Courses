using Microsoft.AspNetCore.Mvc;

namespace Courses.UI.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
