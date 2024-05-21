
using School_System.Data.Entities;

namespace School_System.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Task<IQueryable<Department>> GetAllStudentsPaginated(string? search);
        Task<Department> GetDepartmentById(int id);
        Task<bool> AddDepartment(Department department);
        Task<bool> EditDepartment(Department editedDepartment);
        Task<bool> DeleteDepartment(int id);
    }
}
