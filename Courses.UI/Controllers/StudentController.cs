using Microsoft.AspNetCore.Mvc;

namespace Courses.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
