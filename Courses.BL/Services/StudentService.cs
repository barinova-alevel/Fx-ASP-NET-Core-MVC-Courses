using Courses.DAL.Models.Dtos;
using Courses.DAL.Repositories;
using Serilog;

namespace Courses.BL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                Log.Logger.Information($"Student with Id {id} not found");
                return null;
            }

            return new StudentDto
            {
                StudentId = student.StudentId,
                GroupId = student.GroupId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
    }
}

