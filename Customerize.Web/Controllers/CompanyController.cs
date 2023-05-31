using AutoMapper;
using Customerize.Core.DTOs.Company;
using Customerize.Core.DTOs.Product;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace Customerize.Web.Controllers
{
    public class CompanyController : Controller
    {
        #region DI
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ICategoryService _categoryService;
        private readonly IProductTypeService _companyTypeService;
        #endregion
        public CompanyController(IMapper mapper, ICompanyService companyService, ICategoryService categoryService, IProductTypeService companyTypeService)
        {
            _mapper = mapper;
            _companyService = companyService;
            _categoryService = categoryService;
            _companyTypeService = companyTypeService;
        }
        #region CompanyList
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _companyService.GetCompanyAllDetail();
            return View(result.Data);
        }
        #endregion

        #region CompanyCreate
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyTypes = await _companyTypeService.GetAllAsync();
            ViewBag.companyTypes = new SelectList(companyTypes.Data, "Id", "Name");

            var categories = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(categories.Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyDtoInsert model)
        {
            var result = await _companyService.Create(model);
            return RedirectToAction("GetAllList");
        }
        #endregion

        #region Company Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var result = await _companyService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                var companyDto = _mapper.Map<CompanyDtoUpdate>(result.Data);
                return View(companyDto);
            }
            return RedirectToAction("GetAllList");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyDtoUpdate model)
        {
            var map = _mapper.Map<Company>(model);
            var result = await _companyService.UpdateAsync(map);
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
            var company = await _companyService.GetByIdAsync(Id);
            var result = await _companyService.RemoveAsync(company.Data);
            #endregion
            return RedirectToAction("GetAllList");

        }
        #endregion

        #region CompanyRemoveRange

        [HttpGet]
        public async Task<IActionResult> RemoveRange()
        {
            var companyList = await _companyService.GetCompanyAllDetail();
            if (companyList.Data == null)
            {
                return View();
            }
            var map = _mapper.Map<IList<CompanyDtoRemoveRange>>(companyList.Data);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRangeConfirm(IList<CompanyDtoRemoveRange> model)
        {
            var result = await _companyService.RemoveRangeCompany(model);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(result);

            if (result.IsSuccess)
            {
                return Json(jsonString);
            }
            return RedirectToAction("RemoveRange");
        }
        #endregion



        public IActionResult Index()
        {
            return View();
        }
    }
}
