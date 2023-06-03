using AutoMapper;
using Customerize.Core.DTOs.Advertisement;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class DefinitionsController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly IService<Advertisement> _service;


        #endregion
        public DefinitionsController(IMapper mapper, IService<Advertisement> service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            var map = _mapper.Map<IEnumerable<AdvertisementDtoList>>(result.Data);
            return View(map);
        }

    }
}