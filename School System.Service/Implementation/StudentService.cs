using Microsoft.EntityFrameworkCore;
using School_System.Data.Entities;
using School_System.Infrastructure.Implementation;
using School_System.Infrastructure.Interfaces;
using School_System.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        public StudentService(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentById(string id)
        {
            return await _studentRepository.GetByIdAsync(id);

        }

        public async Task<List<Student>> GetAllStudents()
        {
            var query = await _studentRepository.GetAllAsync(x => x.Department);
            return await query.ToListAsync();
        }
    }
}
