using System.Text.Json;
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
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data loading is currently disabled
            /*
            var courses = LoadSeedData<Course>("courses.json");

            if (courses != null)
            {
                modelBuilder.Entity<Course>().HasData(courses);
            }

            var groups = LoadSeedData<StudentsGroup>("groups.json");

            if (groups != null)
            {
                modelBuilder.Entity<StudentsGroup>().HasData(groups);
            }

            var students = LoadSeedData<Student>("students.json");

            if (students != null)
            {
                modelBuilder.Entity<Student>().HasData(students);
            }
            */
        }

        private List<T> LoadSeedData<T>(string filePath)
        {
            try
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load seed data: {ex.Message}");
                return null;
            }
        }
    }
}
