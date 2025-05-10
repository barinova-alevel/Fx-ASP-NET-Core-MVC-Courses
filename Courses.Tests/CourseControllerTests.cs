using Microsoft.AspNetCore.Mvc;
using Moq;
using Courses.BL.Services;
using Courses.UI.Controllers;
using Courses.DAL.Models.Dtos;
using Xunit;

namespace Courses.Tests
{
    public class CourseControllerTests
    {
        private readonly Mock<ICourseService> _mockCourseService;
        private readonly CoursesController _controller;

        public CourseControllerTests()
        {
            _mockCourseService = new Mock<ICourseService>();
            _controller = new CoursesController(_mockCourseService.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithCourses()
        {
            // Arrange
            var expectedCourses = new List<CourseDto>
            {
                new CourseDto { CourseId = 1, Name = "Test Course 1", Description = "Description 1" },
                new CourseDto { CourseId = 2, Name = "Test Course 2", Description = "Description 2" }
            };

            _mockCourseService.Setup(x => x.GetAllCoursesAsync())
                .ReturnsAsync(expectedCourses);

            // Act
            var result = await _controller.Index(null, null, null, null, null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CourseDto>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Index_WithSelectedCourseId_ExpandsCourse()
        {
            // Arrange
            var courses = new List<CourseDto>
            {
                new CourseDto { CourseId = 1, Name = "Test Course 1", Description = "Description 1" }
            };

            _mockCourseService.Setup(x => x.GetAllCoursesAsync())
                .ReturnsAsync(courses);

            // Act
            var result = await _controller.Index(1, null, null, null, null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var expandedCourseIds = viewResult.ViewData["ExpandedCourseIds"] as List<int>;
            Assert.Contains(1, expandedCourseIds);
        }

        [Fact]
        public async Task Index_WithHideCourse_RemovesCourseFromExpanded()
        {
            // Arrange
            var courses = new List<CourseDto>
            {
                new CourseDto { CourseId = 1, Name = "Test Course 1", Description = "Description 1" }
            };

            _mockCourseService.Setup(x => x.GetAllCoursesAsync())
                .ReturnsAsync(courses);

            // Act
            var result = await _controller.Index(1, new List<int> { 1 }, true, null, null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var expandedCourseIds = viewResult.ViewData["ExpandedCourseIds"] as List<int>;
            Assert.DoesNotContain(1, expandedCourseIds);
        }
    }
}