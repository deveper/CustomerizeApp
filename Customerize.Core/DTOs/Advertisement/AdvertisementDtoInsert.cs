namespace Customerize.Core.DTOs.Advertisement
{
    public class AdvertisementDtoInsert : BaseDto
    {
        public string Title { get; set; }
        public string? Topic { get; set; }
        public string Description { get; set; }
    }
}
