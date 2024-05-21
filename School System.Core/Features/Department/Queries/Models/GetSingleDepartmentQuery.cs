using MediatR;
using School_System.Core.Features.Departments.Queries.Results;

namespace School_System.Core.Features.Departments.Queries.Models
{
    public class GetSingleDepartmentQuery: IRequest<GetSingleDepartmentResponse>
    {
        public int Id { get; set; }
        public GetSingleDepartmentQuery(int id) 
        {
            Id = id;
        }
    }
}
