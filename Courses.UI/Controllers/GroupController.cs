using Courses.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Courses.UI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IStudentsGroupService _studentsGroupService;
        public IActionResult Index()
        {
            return View();
        }
        
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGroupById(int id)
        //{
        //    try
        //    {
        //        var group = await _studentsGroupService.GetGroupByIdAsync(id); //null ref exception
        //        return Ok(group); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message); //handle not founf
        //    }
        //}
    }
}
