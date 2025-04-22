using System;
using Courses.DAL.Data.Entities;

namespace Courses.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        //Uncomment when db context is added:

        //private readonly AppDbContext _context;

        //public CourseRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<Course> GetByIdAsync(int id)
        //{
        //    return await _context.Courses.FindAsync(id);
        //}

        //public async Task<IEnumerable<Course>> GetAllAsync()
        //{
        //    return await _context.Courses.ToListAsync();
        //}
        public Task<IEnumerable<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
