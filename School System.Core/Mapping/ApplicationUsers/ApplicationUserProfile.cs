using AutoMapper;

namespace School_System.Core.Mapping.ApplicationUsers
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            RegisterUserMapping();
        }
    }
}
