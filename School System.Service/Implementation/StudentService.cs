﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_System.Data.Entities;
using School_System.Infrastructure.Interfaces;
using School_System.Service.Interfaces;

namespace School_System.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student, int> _studentRepository;
        public StudentService(IGenericRepository<Student, int> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id, true, s => s.Department);
            return student;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            var query = await _studentRepository.GetAllAsync(x => x.Department);
            return await query.ToListAsync();
        }
        public async Task<IQueryable<Student>> GetAllStudentsPaginated(string? search)
        {
            var students = await _studentRepository.GetAllAsync(x => x.Department);
            if (!string.IsNullOrEmpty(search))
            {
                students.Where(s => s.Name.Contains(search) || s.Address.Contains(search)
                || s.Department.DepartmentName.Contains(search) || s.Phone.Contains(search));
            }
            return students;
        }
        public async Task<bool> AddStudent(Student student)
        {
            var reposone = await _studentRepository.AddAsync(student);
            return reposone is Student;
        }
        public async Task<bool> EditStudent(Student editedStudent)
        {
            await _studentRepository.UpdateAsync(editedStudent);
            return true;
        }
        public async Task<bool> IsStudentExists(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is not null)
            {
                await _studentRepository.DeleteAsync(student);
                return true;
            }
            return false;
        }

    }
}
