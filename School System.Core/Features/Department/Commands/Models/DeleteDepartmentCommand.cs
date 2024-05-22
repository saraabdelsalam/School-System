using MediatR;

namespace School_System.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
