using System;
using Courses.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CoursesDbContext _context;

        public CourseRepository(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
    }
}
