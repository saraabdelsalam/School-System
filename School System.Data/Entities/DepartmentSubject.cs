using System.ComponentModel.DataAnnotations;

namespace School_System.Data.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Key]
        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}
