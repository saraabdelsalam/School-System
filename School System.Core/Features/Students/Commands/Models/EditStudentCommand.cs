using MediatR;
using System.ComponentModel.DataAnnotations;

namespace School_System.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<bool>
    {
        [Required]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DepartmentId { get; set; }
    }

}
