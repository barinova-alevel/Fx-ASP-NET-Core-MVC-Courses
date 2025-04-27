using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ConnectionStrings__DefaultConnection");
                /*const string connectionString = "Server=OKSANA_NANGA;Database=BooksDb;Trusted_Connection=True;TrustServerCertificate=True;";*/
                optionsBuilder.UseOracle(connectionString);
                optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Name = "Business", Description= "Field of study that deals with the principles of business, management, and economics. It combines elements of accountancy, finance, marketing, organizational studies, human resource management, and operations." });
            modelBuilder.Entity<StudentsGroup>().HasData(
                new StudentsGroup { StudentsGroupId=1,CourseId = 1, Name = "BR-01" });
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, GroupId = 1, FirstName= "Elijah", LastName = "Hall" });
        }
    }
}
