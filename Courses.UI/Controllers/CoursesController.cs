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

        public async Task<IActionResult> Index(
            int? selectedCourseId, 
            List<int> expandedCourseIds = null, 
            bool? hideCourse = null,
            int? selectedGroupId = null,
            List<int> expandedGroupIds = null,
            bool? hideGroup = null)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            
            var expandedCourseIdsList = expandedCourseIds ?? new List<int>();
            if (hideCourse == true && selectedCourseId.HasValue)
            {
                expandedCourseIdsList.Remove(selectedCourseId.Value);
            }
            else if (selectedCourseId.HasValue && !expandedCourseIdsList.Contains(selectedCourseId.Value))
            {
                expandedCourseIdsList.Add(selectedCourseId.Value);
            }
            
            var expandedGroupIdsList = expandedGroupIds ?? new List<int>();
            if (hideGroup == true && selectedGroupId.HasValue)
            {
                expandedGroupIdsList.Remove(selectedGroupId.Value);
            }
            else if (selectedGroupId.HasValue && !expandedGroupIdsList.Contains(selectedGroupId.Value))
            {
                expandedGroupIdsList.Add(selectedGroupId.Value);
            }
            
            ViewBag.ExpandedCourseIds = expandedCourseIdsList;
            ViewBag.ExpandedGroupIds = expandedGroupIdsList;
            ViewBag.SelectedCourseId = selectedCourseId;
            ViewBag.SelectedGroupId = selectedGroupId;
            
            return View(courses);
        }
    }
}
