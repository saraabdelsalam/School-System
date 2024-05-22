using AutoMapper;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void EditDepartmentMapping()
        {
            CreateMap<EditDepartmentCommand, Department>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.id))
                                                          .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Name))
                                                          .ForMember(d => d.InsManager, opt => opt.MapFrom(s => s.DeepartmentManagerId));
        }
    }
}
