
using MediatR;
using School_System.Core.Bases;

namespace School_System.Core.Features.ApplicationUsers.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
