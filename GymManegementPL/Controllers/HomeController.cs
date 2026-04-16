using GymManagementBLL.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAnalytiecsService _analytiecsService;

        public HomeController(IAnalytiecsService analytiecsService)
        {
           _analytiecsService = analytiecsService;
        }


        public ActionResult Index()
        {

            var Data = _analytiecsService.GetAnalyticesData(); 
            return View(Data);
        }
    }
}
