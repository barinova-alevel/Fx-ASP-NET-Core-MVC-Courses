using Courses.DAL.Models.Dtos;
using Courses.BL.Models;

namespace Courses.BL.Services
{
    public interface IStudentsGroupService
    {
        Task<StudentsGroupDto> GetGroupByIdAsync(int id);
        Task<IEnumerable<StudentsGroupDto>> GetAllGroupsAsync();
        Task<StudentsGroupDto> UpdateGroupAsync(int id, StudentsGroupDto groupDto);
        Task<OperationResult> DeleteGroupAsync(int id);
        Task<IEnumerable<StudentsGroupDto>> GetAvailableGroupsAsync(int currentGroupId);
        Task<OperationResult> ClearGroupAsync(int sourceGroupId, int targetGroupId);
    }
}
