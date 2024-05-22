using MediatR;

namespace School_System.Core.Features.Departments.Commands.Models
{
    public class EditDepartmentCommand : IRequest<bool>
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int? DeepartmentManagerId { get; set; }
    }
}
