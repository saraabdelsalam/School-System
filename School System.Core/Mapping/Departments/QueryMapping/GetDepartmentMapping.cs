
using School_System.Core.Features.Departments.Queries.Results;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentMapping()
        {
            CreateMap<Department, GetSingleDepartmentResponse>()
                    .ForMember(d=>d.DepartmentManager, opt=>opt.MapFrom(s=>s.Instructor.Name))
                    .ForMember(d => d.Instructors, opt => opt.MapFrom(s => s.Instructors))
                    .ForMember(d => d.DepartmentSubjects, opt => opt.MapFrom(s => s.DepartmentSubjects.Select(s=>s.Subjects)));
        }
    }
}
