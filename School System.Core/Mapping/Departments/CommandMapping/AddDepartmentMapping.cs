using AutoMapper;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void AddDepartmentMapping()
        {
            CreateMap<AddDepartmentCommand, Department>().ReverseMap();
        }

    }
}
