using School_System.Core.Features.Students.Commands.Models;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Mapping.Students
{
    public partial class StudentsProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>();
                    
        }
    }
}
