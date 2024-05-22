
using Microsoft.EntityFrameworkCore;
using School_System.Data.Entities;
using School_System.Infrastructure.Implementation;
using School_System.Infrastructure.Interfaces;
using School_System.Service.Interfaces;

namespace School_System.Service.Implementation
{
    public class DepartmentService : IDepartmentService

    {
        #region Fields 
        private readonly IGenericRepository<Department, int> _departmentRepository;
        #endregion
        #region Constructors
        public DepartmentService(IGenericRepository<Department, int> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        #region Methods
        public async Task<bool> AddDepartment(Department department)
        {
            var response = await _departmentRepository.AddAsync(department);
            return response is Department;
        }

        public Task<bool> DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditDepartment(Department editedDepartment)
        {
            throw new NotImplementedException();
        }
        public async Task<IQueryable<Department>> GetAllDepartments(string? search)
        {
            var departments = _departmentRepository.Find(d => d.Id != 0).Include(d => d.Instructor)
                                                  .Include(d => d.Instructors)
                                                  .Include(d => d.DepartmentSubjects).ThenInclude(d => d.Subjects).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                departments.Where(d => d.DepartmentName.Contains(search));
            }
            return departments;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.Find(d => d.Id == id)
                                                  .Include(d => d.Instructor)
                                                  .Include(d => d.Instructors)
                                                  .Include(d => d.DepartmentSubjects).ThenInclude(d => d.Subjects)
                                                  .FirstOrDefaultAsync();

            return department;

        }
        #endregion
    }
}
