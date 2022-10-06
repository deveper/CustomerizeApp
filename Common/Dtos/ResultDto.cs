using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int? Total { get; set; }
        public long? Time { get; set; }
    }
    public class ResultDto<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
        public int Total { get; set; }
    }
}
