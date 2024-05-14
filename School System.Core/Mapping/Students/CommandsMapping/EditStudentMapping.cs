using School_System.Core.Features.Students.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.Students
{
    public partial class StudentsProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                      .ForMember(x=>x.Id,opt=>opt.MapFrom(s=>s.StudentId));

        }
    }
}
