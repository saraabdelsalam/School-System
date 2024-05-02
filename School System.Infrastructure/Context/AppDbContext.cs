using Microsoft.EntityFrameworkCore;
using School_System.Data.Entities;

namespace School_System.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { 

        }

        DbSet<Student> Students { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        DbSet<StudentSubjects> StudentSubjects { get; set; }
 
    }
}
