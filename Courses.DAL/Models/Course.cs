using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.DAL.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();
    }
}
