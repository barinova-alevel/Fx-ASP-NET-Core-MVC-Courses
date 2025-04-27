using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.DAL
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {
            
        }

        public CoursesDbContext()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentsGroup> StudentsGroups { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        const string connectionString = "Server=OKSANA_NANGA;Database=BooksDb;Trusted_Connection=True;TrustServerCertificate=True;";
        //        optionsBuilder.UseSqlServer(connectionString);
        //        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        //    }
        //}


    }
}
