using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
      
        public GetStudentPaginatedListResponse(int Id, string Name, string PhoneNumber, string Address, string DepartmentName) 
        {
            StudentId = Id;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.DepartmentName = DepartmentName;
        }    
    }
}
