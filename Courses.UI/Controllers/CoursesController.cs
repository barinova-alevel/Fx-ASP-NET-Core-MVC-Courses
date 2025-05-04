using Courses.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courses.UI.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index(int? selectedCourseId, List<int> expandedCourseIds = null, bool? hideCourse = null)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var expandedIds = expandedCourseIds ?? new List<int>();
            
            if (hideCourse == true && selectedCourseId.HasValue)
            {
                expandedIds.Remove(selectedCourseId.Value);
            }
            else if (selectedCourseId.HasValue && !expandedIds.Contains(selectedCourseId.Value))
            {
                expandedIds.Add(selectedCourseId.Value);
            }
            
            ViewBag.ExpandedCourseIds = expandedIds;
            ViewBag.SelectedCourseId = selectedCourseId;
            return View(courses);
        }
    }
}
