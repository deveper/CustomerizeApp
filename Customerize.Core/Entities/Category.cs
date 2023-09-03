namespace Customerize.Core.Entities
{
    public class Category : BaseEntity
    {
      
        public string Name { get; set; }
        public string Code { get; set; }

        //navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
