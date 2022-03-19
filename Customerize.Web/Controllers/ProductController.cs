using AutoMapper;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
