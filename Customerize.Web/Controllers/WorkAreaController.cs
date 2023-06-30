using AutoMapper;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Product;
using Customerize.Core.DTOs.WorkArea;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace Customerize.Web.Controllers
{
    public class WorkAreaController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly IWorkAreaService _workAreaService;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _companyTypeService;
        #endregion
        public WorkAreaController(IMapper mapper, IWorkAreaService workAreaService, ICategoryService categoryService, IProductTypeService companyTypeService)
        {
            _mapper = mapper;
            _workAreaService = workAreaService;
            _categoryService = categoryService;
            _companyTypeService = companyTypeService;
        }
        #region CompanyList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _workAreaService.GetWorkAreaAllDetail();
            return View(result.Data);
        }
        #endregion

        #region CompanyCreate
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkAreaDtoInsert model)
        {
            var result = await _workAreaService.Create(model);
            return RedirectToAction("GetAllList");
        }
        #endregion

        #region Company Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var result = await _workAreaService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                var companyDto = _mapper.Map<WorkAreaDtoUpdate>(result.Data);
                return View(companyDto);
            }
            return RedirectToAction("GetAllList");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkAreaDtoUpdate model)
        {
            var map = _mapper.Map<WorkArea>(model);
            var result = await _workAreaService.UpdateAsync(map);
            if (result.IsSuccess)
            {
                return RedirectToAction("GetAllList");
            }
            return View(model);
        }
        #endregion

        #region Company Remove

        [HttpPost]
        public async Task<IActionResult> Remove(int Id)
        {
            #region :)
            var company = await _workAreaService.GetByIdAsync(Id);
            var result = await _workAreaService.RemoveAsync(company.Data);
            #endregion
            return RedirectToAction("GetAllList");

        }
        #endregion

        #region CompanyRemoveRange

        [HttpGet]
        public async Task<IActionResult> RemoveRange()
        {
            var companyList = await _workAreaService.GetWorkAreaAllDetail();
            if (companyList.Data == null)
            {
                return View();
            }
            var map = _mapper.Map<IList<CompanyDtoRemoveRange>>(companyList.Data);
            return View(map);
        }
        [HttpPost]
        #endregion



        public IActionResult Index()
        {
            return View();
        }
    }
}
