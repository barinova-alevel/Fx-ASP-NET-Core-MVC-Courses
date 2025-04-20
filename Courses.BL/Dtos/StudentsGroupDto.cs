using Courses.DAL.Data.Entities;

namespace Courses.DAL.Models.Dtos
{
    public class StudentsGroupDto
    {
        public int StudentsGroupId { get; set; }
        public int CourseId { get; set; }
        public string? Name { get; set; }
        //public virtual Course Course { get; set; } = null!;
        public virtual ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
