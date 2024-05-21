using School_System.Core.Features.Departments.Queries.Results;

namespace School_System.Core.Features.Departments.Queries.Results
{
    public class GetAllDepartmentsResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
        public List<Instructors> Instructors { get; set; }
        public List<Subjects> DepartmentSubjects { get; set; }
        public GetAllDepartmentsResponse(int Id, string DepartmentName, string DepartmentManager, List<Instructors> Instructors, List<Subjects> DepartmentSubjects)
        {
            this.Id = Id;
            this.DepartmentName = DepartmentName;
            this.DepartmentManager = DepartmentManager;
            this.Instructors = Instructors;
            this.DepartmentSubjects = DepartmentSubjects;
        }
    }
}
