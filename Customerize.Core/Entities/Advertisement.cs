namespace Customerize.Core.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string? Topic { get; set; }
        public string Description { get; set; }

        //navigation property
        public long UserId { get; set; }
        public AspNetUser AppUser { get; set; }
    }
}
