namespace Customerize.Core.Entities
{
    public class AppUser : BaseEntity
    {
        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        //navigation property
        public IQueryable<Order> Orders { get; set; }
        public IQueryable<Advertisement>? Advertisements { get; set; }
    }
}
