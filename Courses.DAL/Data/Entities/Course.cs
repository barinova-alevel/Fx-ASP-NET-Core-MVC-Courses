namespace Courses.DAL.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();
    }
}
