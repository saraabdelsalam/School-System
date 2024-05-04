using School_System.Data.Entities;
using School_System.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
    }
}
