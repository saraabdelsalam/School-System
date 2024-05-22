using MediatR;

namespace School_System.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
