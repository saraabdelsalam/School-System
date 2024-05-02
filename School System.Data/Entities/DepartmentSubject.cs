using School_System.Data.Common;

namespace School_System.Data.Entities
{
    public class DepartmentSubject : BaseEntity<int>
    {
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}
