using Microsoft.AspNetCore.Identity;

namespace Customerize.Core.Entities
{
    public class AspNetUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        //public ICollection<Advertisement>? Advertisements { get; set; }
        //public ICollection<Order>? Orders { get; set; }
    }
}
