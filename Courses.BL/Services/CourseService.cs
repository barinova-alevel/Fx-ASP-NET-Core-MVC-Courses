using Courses.DAL.Models.Dtos;
using Courses.DAL.Repositories;
using Serilog;

namespace Courses.BL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentsGroupRepository _groupRepository;
        public CourseService(ICourseRepository courseRepository, IStudentsGroupRepository groupRepository)
        {
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                Name = c.Name,
                Description = c.Description,
                StudentsGroups = c.StudentsGroups.Select(g => new StudentsGroupDto
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
                }).ToList()
            });
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            { 
                Log.Logger.Information($"Course with Id {id} not found");
                return null;
            }

            return new CourseDto
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                StudentsGroups = course.StudentsGroups.Select(g => new StudentsGroupDto
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
                }).ToList()
            };
        }
    }
}
