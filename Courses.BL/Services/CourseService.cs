using Courses.DAL.Models.Dtos;
using Courses.DAL.Repositories;

namespace Courses.BL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                Name = c.Name,
                Description = c.Description
            });
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) throw new Exception("Course not found");

            return new CourseDto
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description
            };
        }
    }
}
