using Courses.DAL.Data.Entities;

namespace Courses.DAL.Repositories
{
    public interface IStudentsGroupRepository
    {
        Task<IEnumerable<StudentsGroup>> GetAllAsync();

        Task<StudentsGroup> GetByIdAsync(int id);
    }
}
