using Courses.DAL.Models.Dtos;

namespace Courses.BL.Services
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
    }
}
