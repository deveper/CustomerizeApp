namespace Customerize.Core.Entities
{
    public class Shipper : BaseEntity
    {
        public string Name { get; set; }
        public string WorkRegion { get; set; }

        //navigation property
        public ICollection<Order> Orders { get; set; }

        //navigation property
        public ICollection<RegionShipper> RegionShippers { get; set; }

    }
}
