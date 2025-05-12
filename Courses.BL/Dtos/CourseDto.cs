namespace Courses.DAL.Models.Dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<StudentsGroupDto> StudentsGroups { get; set; } = new List<StudentsGroupDto>();
    }
}
