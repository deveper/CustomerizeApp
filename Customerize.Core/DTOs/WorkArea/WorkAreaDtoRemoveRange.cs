using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Customerize.Core.DTOs.Product
{
    public class WorkAreaDtoRemoveRange : BaseDto
    {
        public WorkAreaDtoRemoveRange()
        {

            DeleteProducts = new SelectListItem();
        }
        public string? Name { get; set; }

        public bool isInternal { get; set; }
        public SelectListItem? DeleteProducts { get; set; }
    }
}
