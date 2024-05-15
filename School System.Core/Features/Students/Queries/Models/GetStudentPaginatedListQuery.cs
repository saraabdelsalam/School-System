using MediatR;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Core.Wrapper;
using School_System.Data.Enums;

namespace School_System.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
