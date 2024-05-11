using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;
namespace School_System.Core.Mapping.Students
{
    public partial class StudentsProfile
    {
        public void GetStudentBIydMapping()
        {
            CreateMap<Student, GetStudentResponse>()
                    .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department.DepartmentName));
        }
    }
}