
using MediatR;

namespace School_System.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentCommand : IRequest<string>
    {
        public string DepartmentName { get; set; }
    }
}
