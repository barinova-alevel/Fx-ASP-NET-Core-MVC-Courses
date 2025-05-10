using Moq;
using Courses.BL.Services;
using Courses.UI.Controllers;
using Courses.DAL.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Courses.BL.Models;

namespace Courses.Tests;

public class GroupControllerTests
{
    private readonly Mock<IStudentsGroupService> _mockGroupService;
    private readonly GroupController _controller;

    public GroupControllerTests()
    {
        _mockGroupService = new Mock<IStudentsGroupService>();
        _controller = new GroupController(_mockGroupService.Object);
    }

    [Fact]
    public async Task Edit_Get_WithValidId_ReturnsView()
    {
        // Arrange
        var group = new StudentsGroupDto { StudentsGroupId = 1, Name = "Test Group" };
        _mockGroupService.Setup(x => x.GetGroupByIdAsync(1))
            .ReturnsAsync(group);

        // Act
        var result = await _controller.Edit(1);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<StudentsGroupDto>(viewResult.Model);
        Assert.Equal(1, model.StudentsGroupId);
    }

    [Fact]
    public async Task Edit_Get_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        _mockGroupService.Setup(x => x.GetGroupByIdAsync(1))
            .ReturnsAsync((StudentsGroupDto)null);

        // Act
        var result = await _controller.Edit(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Edit_Post_WithValidModel_RedirectsToIndex()
    {
        // Arrange
        var group = new StudentsGroupDto { StudentsGroupId = 1, Name = "Test Group" };
        _mockGroupService.Setup(x => x.UpdateGroupAsync(1, group))
            .ReturnsAsync(group);

        // Act
        var result = await _controller.Edit(1, group);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("Courses", redirectResult.ControllerName);
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
    }

    [Fact]
    public async Task ClearGroup_Get_WithValidId_ReturnsView()
    {
        // Arrange
        var group = new StudentsGroupDto { StudentsGroupId = 1, Name = "Test Group" };
        var availableGroups = new List<StudentsGroupDto>
            {
                new StudentsGroupDto { StudentsGroupId = 2, Name = "Target Group" }
            };

        _mockGroupService.Setup(x => x.GetGroupByIdAsync(1))
            .ReturnsAsync(group);
        _mockGroupService.Setup(x => x.GetAvailableGroupsAsync(1))
            .ReturnsAsync(availableGroups);

        // Act
        var result = await _controller.ClearGroup(1);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<StudentsGroupDto>(viewResult.Model);
        Assert.Equal(1, model.StudentsGroupId);
        Assert.Equal(availableGroups, viewResult.ViewData["AvailableGroups"]);
    }

    [Fact]
    public async Task ClearGroup_Post_WithValidIds_RedirectsToIndex()
    {
        // Arrange
        var result = new OperationResult { Success = true, Message = "Students moved successfully" };
        _mockGroupService.Setup(x => x.ClearGroupAsync(1, 2))
            .ReturnsAsync(result);

        // Act
        var actionResult = await _controller.ClearGroup(1, 2);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(actionResult);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("Courses", redirectResult.ControllerName);
    }
}
