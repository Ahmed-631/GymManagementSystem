using GymManagementBLL.Service.Classes;
using GymManagementBLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _SessionService;

        public SessionController(ISessionService SessionService)
        {
            _SessionService = SessionService;
        }
        public ActionResult Index()
        {
            var Sessions = _SessionService.GetAllSessions();
            return View(Sessions);
        }


        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                TempData["Error Massage"] = " Id Can Not By Zero Or Negative ";
                return RedirectToAction(nameof(Index));
            }

            var Session  = _SessionService.GetSessionById(id);
            if (Session is null)
            {
                TempData["Error Massage"] = "  Can Not Found This Session ";
                return RedirectToAction(nameof(Index));
            }

            return View(Session); 

        }

        
    }
}
