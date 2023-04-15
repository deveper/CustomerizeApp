namespace Customerize.Core.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string? Topic { get; set; }
        public string Description { get; set; }

        //navigation property
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
