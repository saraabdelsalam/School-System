
using AutoMapper;
using MediatR;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Data.Entities;
using School_System.Service.Interfaces;

namespace School_System.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, string>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public DepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
        { 
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<string> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            var result = await _departmentService.AddDepartment(department);
            if (result is false)
            {
                return "Failed";
            }
            return "Added Successfully";
        }
    }
}
