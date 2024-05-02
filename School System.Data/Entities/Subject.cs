using School_System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace School_System.Data.Entities
{
    public class Subject : BaseEntity<int>
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();
        }

        [StringLength(500)]
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; }
    }
}
