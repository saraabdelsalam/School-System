
using School_System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_System.Data.Entities
{
    public class Student : BaseEntity<string>
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
