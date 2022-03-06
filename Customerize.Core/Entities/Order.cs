namespace Customerize.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Guid guid = new Guid();
            this.OrderCode = guid.ToString();
        }
        public string OrderCode { get; set; }

        //navigation property
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        //navigation property
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //navigation property
        public ICollection<OrderLine> OrderLines { get; set; }

        //navigation property
        public int UserId { get; set; }
        public Shipper AppUser { get; set; }
    }
}
