using AutoMapper;
using MediatR;
using School_System.Core.Features.Departments.Queries.Models;
using School_System.Core.Features.Departments.Queries.Results;
using School_System.Service.Interfaces;
using School_System.Data.Entities;
using School_System.Core.Wrapper;
using System.Linq.Expressions;
using System;

namespace School_System.Core.Features.Departments.Queries.Handlers
{
    public class GetDepartmentsHandler : IRequestHandler<GetSingleDepartmentQuery, GetSingleDepartmentResponse>,
                                         IRequestHandler<GetAllDepartmentsQuery, PaginatedResult<GetAllDepartmentsResponse>>
    {
        #region Fields 
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetDepartmentsHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion
        #region Handlers
        public async Task<GetSingleDepartmentResponse> Handle(GetSingleDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);
            if (department == null)
            {
                return null;
            }
            var departmentMapped = _mapper.Map<GetSingleDepartmentResponse>(department);
            return departmentMapped;
        }

        public async Task<PaginatedResult<GetAllDepartmentsResponse>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Department, GetAllDepartmentsResponse>> expression = e => new GetAllDepartmentsResponse(e.Id, e.DepartmentName, e.Instructor.Name, (List<Instructors>)e.Instructors, (List<Subjects>)e.DepartmentSubjects.Select(s => s.Subjects));
            var departments = await _departmentService.GetAllDepartments(request.Search);
            var PaginatedResult = await departments.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginatedResult;
        }

        #endregion
    }
}
