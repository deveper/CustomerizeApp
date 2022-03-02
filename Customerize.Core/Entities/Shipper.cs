namespace Customerize.Core.Entities
{
    public class Shipper : BaseEntity
    {
        public string Name { get; set; }
        public string WorkRegion { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
