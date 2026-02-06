using GymManagementBLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
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
