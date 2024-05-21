
using School_System.Data.Entities;
using School_System.Infrastructure.Interfaces;
using School_System.Service.Interfaces;

namespace School_System.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department,int> _departmentRepository;
        public DepartmentService(IGenericRepository<Department,int> departmentRepository)
        { 
            _departmentRepository = departmentRepository;
        }
        public Task<bool> AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditDepartment(Department editedDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Department>> GetAllStudentsPaginated(string? search)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
