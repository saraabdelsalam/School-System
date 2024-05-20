

using System.ComponentModel.DataAnnotations;

namespace School_System.Data.Entities
{
    public class StudentSubjects
    {
        [Key]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Key]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
