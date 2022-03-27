namespace Customerize.Core.Entities
{
    public class RegionShipper : BaseEntity
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}
