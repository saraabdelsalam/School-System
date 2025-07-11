﻿using School_System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace School_System.Data.Entities
{
    public class Student : BaseEntity<int>
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<StudentSubjects> StudentSubject { get; set; }

    }
}
