using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.Students
{
    public partial class StudentsProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                    .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department.DepartmentName));
        }
    }
}
