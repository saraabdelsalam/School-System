using Microsoft.EntityFrameworkCore;
using School_System.Data.Entities;
using School_System.Infrastructure.Context;
using School_System.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Infrastructure.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        #endregion
        #region Constructors
        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Functionalities

        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }
        #endregion
    }
}
