using Customerize.Core.DTOs.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Core.Services
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeDtoList>> GetAllProductType();
    }
}
