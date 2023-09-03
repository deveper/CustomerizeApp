namespace Customerize.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        //navigation property
        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        //navigation property
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //navigation property
        public ICollection<OrderLine>? OrderLines { get; set; }
        //navigation property
        public ICollection<ProductDocument>? ProductDocuments { get; set; }
    }
}
