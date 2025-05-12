using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Courses.BL.Services;
using Courses.UI.Controllers;
using Courses.DAL.Models.Dtos;
using Courses.BL.Models;
using Xunit;
using Microsoft.AspNetCore.Http;

namespace Courses.Tests.Controllers
{
    public class GroupControllerTests
    {
        private readonly Mock<IStudentsGroupService> _mockGroupService;
        private readonly GroupController _controller;
        private readonly ITempDataDictionary _tempData;

        public GroupControllerTests()
        {
            _mockGroupService = new Mock<IStudentsGroupService>();
            _controller = new GroupController(_mockGroupService.Object);

            // Initialize TempData
            _tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            _controller.TempData = _tempData;
        }

        [Fact]
        public async Task Delete_WithValidId_RedirectsToIndex()
        {
            // Arrange
            var result = new OperationResult { Success = true, Message = "Group deleted successfully" };
            _mockGroupService.Setup(x => x.DeleteGroupAsync(1))
                .ReturnsAsync(result);

            // Act
            var actionResult = await _controller.Delete(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Courses", redirectResult.ControllerName);
            Assert.Equal("Group deleted successfully", _tempData["SuccessMessage"]);
        }

        
        [Fact]
        public async Task Delete_WithGroupHavingStudents_RedirectsToIndexWithErrorMessage()
        {
            // Arrange
            var result = new OperationResult { Success = false, Message = "Cannot delete group: There are students assigned to this group" };
            _mockGroupService.Setup(x => x.DeleteGroupAsync(1))
                .ReturnsAsync(result);

            // Act
            var actionResult = await _controller.Delete(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Courses", redirectResult.ControllerName);
            Assert.Equal("Cannot delete group: There are students assigned to this group", _tempData["ErrorMessage"]);
        }
    }
}