using Courses.DAL.Models.Dtos;

namespace Courses.BL.Services
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentByIdAsync(int id);
    }
}
