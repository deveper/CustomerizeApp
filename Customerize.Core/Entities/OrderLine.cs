namespace Customerize.Core.Entities
{
    public class OrderLine : BaseEntity
    {
        //navigation property
        public int OrderId { get; set; }
        public Order Order { get; set; }

        //navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
