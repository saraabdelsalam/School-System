using School_System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_System.Data.Entities
{
    public class Instructor_Subjects
    {
        [Key]
        public int InstructorId { get; set; }
        [Key]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        [InverseProperty("Ins_Subjects")]
        public Instructor? instructor { get; set; }

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Ins_Subjects")]
        public Subject? Subjects { get; set; }
    }
}
