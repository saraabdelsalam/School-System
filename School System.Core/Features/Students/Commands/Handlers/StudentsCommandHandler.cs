using AutoMapper;
using MediatR;
using School_System.Core.Features.Students.Commands.Models;
using School_System.Data.Entities;
using School_System.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Commands.Handlers
{
    public class StudentsCommandHandler : IRequestHandler<AddStudentCommand, string>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public StudentsCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region Handlers
        public async Task<string> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var response = await _studentService.AddStudent(student);
            return response is true? "added Successfully" : "Failed";
        }
        #endregion
    }
}
