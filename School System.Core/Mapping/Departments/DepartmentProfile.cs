using AutoMapper;

namespace School_System.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            GetDepartmentMapping();
            AddDepartmentMapping();
            EditDepartmentMapping();
        }
    }
}
