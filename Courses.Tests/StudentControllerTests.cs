using Courses.BL.Services;
using Courses.DAL.Models.Dtos;
using Courses.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Courses.Tests
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockStudentService;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
            _controller = new StudentController(_mockStudentService.Object);
        }

        [Fact]
        public async Task Details_WithValidId_ReturnsView()
        {
            // Arrange
            var student = new StudentDto
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            _mockStudentService.Setup(x => x.GetStudentByIdAsync(1))
                .ReturnsAsync(student);

            // Act
            var result = await _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<StudentDto>(viewResult.Model);
            Assert.Equal(1, model.StudentId);
            Assert.Equal("John", model.FirstName);
            Assert.Equal("Doe", model.LastName);
        }

        [Fact]
        public async Task Details_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockStudentService.Setup(x => x.GetStudentByIdAsync(1))
                .ReturnsAsync((StudentDto)null);

            // Act
            var result = await _controller.Details(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_Get_WithValidId_ReturnsView()
        {
            // Arrange
            var student = new StudentDto
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            _mockStudentService.Setup(x => x.GetStudentByIdAsync(1))
                .ReturnsAsync(student);

            // Act
            var result = await _controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<StudentDto>(viewResult.Model);
            Assert.Equal(1, model.StudentId);
        }

        [Fact]
        public async Task Edit_Get_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockStudentService.Setup(x => x.GetStudentByIdAsync(1))
                .ReturnsAsync((StudentDto)null);

            // Act
            var result = await _controller.Edit(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_Post_RedirectsToDetails()
        {
            // Arrange
            var student = new StudentDto
            {
                StudentId = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            _mockStudentService.Setup(x => x.UpdateStudentAsync(1, student))
                .ReturnsAsync(student);

            // Act
            var result = await _controller.Edit(1, student);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectResult.ActionName);
            Assert.Equal(1, redirectResult.RouteValues["id"]);
        }
    }
}
