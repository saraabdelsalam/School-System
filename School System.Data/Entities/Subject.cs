using School_System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_System.Data.Entities
{
    public class Subject : BaseEntity<int>
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubjects>();
            DepartmentsSubjects = new HashSet<DepartmentSubject>();
            Ins_Subjects = new HashSet<Instructor_Subjects>();
        }

        [StringLength(500)]
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; }

        [InverseProperty("Subjects")]
        public virtual ICollection<Instructor_Subjects> Ins_Subjects { get; set; }
    }
}
