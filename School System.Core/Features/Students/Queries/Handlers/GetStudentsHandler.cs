using AutoMapper;
using MediatR;
using School_System.Core.Features.Students.Queries.Models;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Core.Wrapper;
using School_System.Data.Entities;
using School_System.Service.Interfaces;
using System.Linq.Expressions;

namespace School_System.Core.Features.Students.Queries.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsListQuery, List<GetStudentResponse>>,
                                      IRequestHandler<GetSingleStudentQuery, GetStudentResponse>,
                                      IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetStudentsHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<List<GetStudentResponse>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetAllStudents();
            var studentListMapped = _mapper.Map<List<GetStudentResponse>>(studentList);
            return studentListMapped;
        }

        public async Task<GetStudentResponse> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(request.id);
            var response = _mapper.Map<GetStudentResponse>(student);
            return response;
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Id, e.Name, e.Phone, e.Address, e.Department.DepartmentName);
            var students = await _studentService.GetAllStudentsPaginated(request.Search);
            var PaginatedResult = await students.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedResult;
        }
    }
}
