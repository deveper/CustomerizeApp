using Microsoft.AspNetCore.Identity;

namespace Customerize.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
