using Courses.DAL.Data.Entities;

namespace Courses.DAL.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
    }
}