namespace Customerize.Core.Entities
{
    public class AppUser : BaseEntity
    {
        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        //navigation property
        public ICollection<Order> Orders { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
