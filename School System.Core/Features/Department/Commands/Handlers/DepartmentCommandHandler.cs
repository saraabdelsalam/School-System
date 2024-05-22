using AutoMapper;
using MediatR;
using School_System.Core.Features.Departments.Commands.Models;
using School_System.Data.Entities;
using School_System.Service.Interfaces;

namespace School_System.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, string>,
                                            IRequestHandler<EditDepartmentCommand, bool>,
                                            IRequestHandler<DeleteDepartmentCommand, bool>
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

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentService.DeleteDepartment(request.Id);
        }

        public async Task<bool> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.id);
            if (department is null)
            {
                return false;
            }
            var departmentMapped = _mapper.Map<Department>(request);
            return await _departmentService.EditDepartment(departmentMapped);
        }
    }
}
