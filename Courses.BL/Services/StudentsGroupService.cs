using Courses.DAL.Models.Dtos;
using Courses.DAL.Repositories;
using Serilog;

namespace Courses.BL.Services
{
     public class StudentsGroupService : IStudentsGroupService
    {
        private readonly IStudentsGroupRepository _groupRepository;
        public StudentsGroupService(IStudentsGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<StudentsGroupDto>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetAllAsync();
            return groups.Select(g => new StudentsGroupDto
            {
                StudentsGroupId = g.StudentsGroupId,
                CourseId = g.CourseId,
                Name = g.Name,
                Students = g.Students.Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    GroupId = s.GroupId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList()
            });
        }

        public async Task<StudentsGroupDto> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                Log.Logger.Information($"Group with Id {id} not found");
            }

            return new StudentsGroupDto
            {
                StudentsGroupId = group.StudentsGroupId,
                CourseId = group.CourseId,
                Name = group.Name,
                Students = group.Students.Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    GroupId = s.GroupId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList()
            };
        }

        public async Task<StudentsGroupDto> UpdateGroupAsync(int id, StudentsGroupDto groupDto)
        {
           var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                Log.Logger.Information($"Group with Id {id} not found");
                return null;
            }
            group.Name = groupDto.Name;
            var updatedGroup = await _groupRepository.UpdateAsync(group);
            return new StudentsGroupDto
            {
                StudentsGroupId = updatedGroup.StudentsGroupId,
                CourseId = updatedGroup.CourseId,
                Name = updatedGroup.Name,
                Students = updatedGroup.Students.Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    GroupId = s.GroupId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList()
            };
        }
    }
}
