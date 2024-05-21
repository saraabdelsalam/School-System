using MediatR;
using School_System.Core.Features.Departments.Queries.Results;
using School_System.Core.Wrapper;

namespace School_System.Core.Features.Departments.Queries.Models
{
    public class GetAllDepartmentsQuery : IRequest<PaginatedResult<GetAllDepartmentsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
