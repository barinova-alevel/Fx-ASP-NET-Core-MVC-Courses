using Courses.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Courses.DAL.Models.Dtos;
using Courses.BL.Models;

namespace Courses.UI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IStudentsGroupService _studentsGroupService;

        public GroupController(IStudentsGroupService studentsGroupService)
        {
            _studentsGroupService = studentsGroupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var group = await _studentsGroupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentsGroupDto group)
        {
            if (id != group.StudentsGroupId)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(group.Name))
            {
                ModelState.AddModelError("Name", "Group name is required");
            }

            if (ModelState.IsValid)
            {
                var updatedGroup = await _studentsGroupService.UpdateGroupAsync(id, group);
                if (updatedGroup == null)
                {
                    return NotFound();
                }
                TempData["SuccessMessage"] = "Group updated successfully";
                return RedirectToAction("Index", "Courses");
            }
            return View(group);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentsGroupService.DeleteGroupAsync(id);
            
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction("Index", "Courses");
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
