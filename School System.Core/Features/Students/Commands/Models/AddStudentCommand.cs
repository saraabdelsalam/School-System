using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone{ get; set; }
        public int DepartmentId { get; set; }
    }
}
