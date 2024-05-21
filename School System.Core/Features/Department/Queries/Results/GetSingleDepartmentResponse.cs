
namespace School_System.Core.Features.Departments.Queries.Results
{
    public class GetSingleDepartmentResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set;}
        public List<Instructors> Instructors { get; set; }
        public List<Subjects> DepartmentSubjects { get; set; }
    }
    public class Instructors
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
    }
}
