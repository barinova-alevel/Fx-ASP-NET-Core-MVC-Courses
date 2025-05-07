using Courses.DAL.Models.Dtos;

namespace Courses.BL.Services
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<StudentDto> UpdateStudentAsync(int id, StudentDto studentDto);
    }
}
