using AutoMapper;
using Customerize.Core.DTOs.DashBoard;
using Customerize.Core.Entities;
using Customerize.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IDashBoardService _dashboardService;
        public DashBoardController(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _dashboardService.Dailygeneral();
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            return View(result.Message);
        }
    }
}
