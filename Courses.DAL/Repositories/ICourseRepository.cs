using Courses.DAL.Data.Entities;

namespace Courses.DAL.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
    }
}
