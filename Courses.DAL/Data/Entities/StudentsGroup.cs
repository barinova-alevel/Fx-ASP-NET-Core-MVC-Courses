namespace Courses.DAL.Data.Entities
{
    public class StudentsGroup
    {
        public int StudentsGroupId { get; set; }

        public int CourseId { get; set; }

        public string? Name { get; set; }

        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
