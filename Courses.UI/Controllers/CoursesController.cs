using Microsoft.AspNetCore.Mvc;

namespace Courses.UI.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
