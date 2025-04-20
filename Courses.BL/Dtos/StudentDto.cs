using Courses.DAL.Data.Entities;

namespace Courses.DAL.Models.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual StudentsGroupDto? Group { get; set; }
    }
}
