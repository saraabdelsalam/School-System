using School_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<IQueryable<Student>> GetAllStudentsPaginated(string? search);
        Task<Student> GetStudentById(int id);
        Task<bool> IsStudentExists(int id);
        Task<bool> AddStudent(Student student);
        Task<bool> EditStudent(Student editedStudent);
        Task<bool> DeleteStudent(int id);       
    }
}
