using AutoMapper;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;


namespace School_System.Core.Mapping.Students
{
    public partial class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            GetStudentListMapping();
            GetStudentBIydMapping();
        }
    }
}
