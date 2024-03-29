﻿using System.Web.Mvc;

namespace Customerize.Core.DTOs.Product
{
    public class ProductDtoList : BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProductTypeId { get; set; }
        public string CategoryName { get; set; }
        public string ProductTypeName { get; set; }

    }
}
