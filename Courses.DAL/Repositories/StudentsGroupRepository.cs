using Courses.DAL.Data.Entities;

namespace Courses.DAL.Repositories
{
    public class StudentsGroupRepository : IStudentsGroupRepository
    {
        public Task<IEnumerable<StudentsGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentsGroup> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
