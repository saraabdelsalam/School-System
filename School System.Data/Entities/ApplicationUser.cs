

using Microsoft.AspNetCore.Identity;

namespace School_System.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
