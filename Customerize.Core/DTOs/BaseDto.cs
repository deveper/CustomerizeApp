using System.ComponentModel.DataAnnotations;

namespace Customerize.Core.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
