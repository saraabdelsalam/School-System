using School_System.Data.Common;

namespace School_System.Data.Entities
{
    public class StudentSubjects : BaseEntity<int>
    {
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
