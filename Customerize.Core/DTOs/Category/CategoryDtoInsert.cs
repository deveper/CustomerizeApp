using Customerize.Common.Helpers;

namespace Customerize.Core.DTOs.Category
{
    public class CategoryDtoInsert : BaseDto
    {

        public CategoryDtoInsert()
        {
            var random = new RandomGenerators();
            this.Code = random.GenarateNumberCode();
        }
        public string Name { get; set; }


    }
}
