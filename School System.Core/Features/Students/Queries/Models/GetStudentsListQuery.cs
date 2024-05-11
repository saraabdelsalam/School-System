using MediatR;
using School_System.Core.Features.Students.Queries.Results;
using School_System.Data.Entities;

namespace School_System.Core.Features.Students.Queries.Models
{
    public class GetStudentsListQuery : IRequest<List<GetStudentResponse>>
    {
    }
}
