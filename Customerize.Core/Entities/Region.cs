namespace Customerize.Core.Entities
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }

        //navigation property
        public ICollection<RegionShipper> RegionShippers { get; set; }
    }
}
