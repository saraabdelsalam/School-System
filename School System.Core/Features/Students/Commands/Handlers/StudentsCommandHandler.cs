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
    public class StudentsCommandHandler : IRequestHandler<AddStudentCommand, string>,
                                          IRequestHandler<EditStudentCommand, bool>,
                                          IRequestHandler<DeleteStudentCommand, bool>
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

        public async Task<bool> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var IsStudentExists = await _studentService.IsStudentExists(request.StudentId);
            if (IsStudentExists)
            {
                var studentMapped = _mapper.Map<Student>(request);
                return await _studentService.EditStudent(studentMapped);
            }
                return false;          
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.DeleteStudent(request.Id);
        }
        #endregion
    }
}
