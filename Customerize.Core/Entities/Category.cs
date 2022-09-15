using Customerize.Core.DTOs.Category;

namespace Customerize.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Code = new Guid().ToString().Substring(0, 10);

        }
        public string Name { get; set; }
        public string? Code { get; set; }

        //navigation property
        public ICollection<Product>? Products { get; set; }

        public static implicit operator Category(CategoryDtoUpdate v)
        {
            throw new NotImplementedException();
        }
    }
}
