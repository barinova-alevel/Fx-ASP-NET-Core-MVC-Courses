using Courses.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CoursesDbContext _context;

        public StudentRepository(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Group)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }
    }
}
