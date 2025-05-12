using Courses.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.DAL.Repositories
{
    public class StudentsGroupRepository : IStudentsGroupRepository
    {
        private readonly CoursesDbContext _context;

        public StudentsGroupRepository(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentsGroup>> GetAllAsync()
        {
            return await _context.StudentsGroups
                .Include(g => g.Course)
                .Include(g => g.Students)
                .ToListAsync();
        }

        public async Task<StudentsGroup> GetByIdAsync(int id)
        {
         return await _context.StudentsGroups
                .Include(g => g.Course)
                .Include(g => g.Students)
                .FirstOrDefaultAsync(g => g.StudentsGroupId == id);
        }

        public async Task<StudentsGroup> UpdateAsync(StudentsGroup group)
        {
            _context.StudentsGroups.Update(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.StudentsGroups.FindAsync(id);
            if (group != null)
            {
                _context.StudentsGroups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MoveStudentsAsync(int sourceGroupId, int targetGroupId)
        {
            var students = await _context.Students
                .Where(s => s.GroupId == sourceGroupId)
                .ToListAsync();

            foreach (var student in students)
            {
                student.GroupId = targetGroupId;
            }

            await _context.SaveChangesAsync();
        }
    }
}
