using AutoMapper;
using MediatR;
using School_System.Core.Features.Students.Queries.Models;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;
using School_System.Service.Interfaces;

namespace School_System.Core.Features.Students.Queries.Handlers
{
    public class GetStudentsListHandler : IRequestHandler<GetStudentsListQuery, List<GetStudentListResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetStudentsListHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<List<GetStudentListResponse>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetAllStudentsAsync();
            var studentListMapped = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return studentListMapped;
        }
    }
}
