using Microsoft.AspNetCore.Mvc;

namespace Customerize.Web.Controllers
{
    public class DashBoardController : Controller
    {

        public DashBoardController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
