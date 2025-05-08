using Courses.DAL.Models.Dtos;

namespace Courses.BL.Services
{
    public interface IStudentsGroupService
    {
        Task<StudentsGroupDto> GetGroupByIdAsync(int id);
        Task<IEnumerable<StudentsGroupDto>> GetAllGroupsAsync();
        Task<StudentsGroupDto> UpdateGroupAsync(int id, StudentsGroupDto groupDto);
    }
}
