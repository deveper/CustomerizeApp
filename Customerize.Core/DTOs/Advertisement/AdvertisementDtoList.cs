using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.DTOs.Advertisement
{
    public class AdvertisementDtoList : BaseDto
    {
        public string Title { get; set; }
        public string? Topic { get; set; }
        public string Description { get; set; }
    }
}
