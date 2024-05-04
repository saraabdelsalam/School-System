using MediatR;
using School_System.Core.Features.Students.Queries.Models;
using School_System.Data.Entities;
using School_System.Service.Interfaces;

namespace School_System.Core.Features.Students.Queries.Handlers
{
    public class GetStudentsListHandler : IRequestHandler<GetStudentsListQuery, List<Student>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion
        #region Constructors
        public GetStudentsListHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion
        public async Task<List<Student>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetAllStudentsAsync();
        }
    }
}
