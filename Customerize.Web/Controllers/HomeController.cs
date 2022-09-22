using AutoMapper;
using Customerize.Core.DTOs.Advertisement;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class HomeController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly IService<Advertisement> _service;


        #endregion
        public HomeController(IMapper mapper, IService<Advertisement> service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            var map = _mapper.Map<IEnumerable<AdvertisementDtoList>>(result);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvertisement([FromBody] AdvertisementDtoInsert model)
        {
            var map = _mapper.Map<Advertisement>(model);
            var result = await _service.AddAsync(map);
            if (result.IsSuccess)
            {
                return Json(result.Message);
            }
            return Json(result);
        }

    }
}