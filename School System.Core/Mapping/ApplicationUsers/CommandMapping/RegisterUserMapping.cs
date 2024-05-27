
using AutoMapper;
using School_System.Core.Features.ApplicationUsers.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Mapping.ApplicationUsers
{
    public partial class ApplicationUserProfile : Profile
    {
        public void RegisterUserMapping()
        {
            CreateMap<RegisterUserCommand, ApplicationUser>();
        }
    }
}
