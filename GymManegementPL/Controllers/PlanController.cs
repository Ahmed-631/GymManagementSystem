using GymManagementBLL.Service.Classes;
using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.PlanViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class PlanController : Controller
    {
        private readonly IplanService _PlanServise; 
        public PlanController(IplanService PlanService)
        {

            _PlanServise = PlanService; 
        }
        public IActionResult Index()
        {

            var Plans = _PlanServise.GetAllPlans();

            return View(Plans);
        }

        public IActionResult PlanDetails(int id)
        {

            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index));
            }
            var Plan = _PlanServise.GetPlanById(id);
            if (Plan is null)
            {
                TempData["ErrorMassage"] = " Plan Not Found ";
                return RedirectToAction(nameof(Index));
            }
            return View(Plan);

        }

        public IActionResult Edit(int id)
        {

            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index));
            }
            var Plan = _PlanServise.GetPlantoUpdate(id);
            if (Plan is null)
            {
                TempData["ErrorMassage"] = " Plan Not Found ";
                return RedirectToAction(nameof(Index));
            }
            return View(Plan);

        }
        [HttpPost]
        public IActionResult Edit( [FromRoute] int id , UpdatePlanViewModel UpdatedPlan ) 
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("WrongData", "Data in Valid"); 
            return View(UpdatedPlan);
            }
            var Result = _PlanServise.UpdatePlan(UpdatedPlan, id);
            if (Result)
            {
                TempData["SuccessMassage"] = "  Plan Updated Successfully ";
            }
            else
            {
                TempData["ErrorMassage"] = " Plan Feild To Update ";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult ToggleState([FromRoute]  int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index));
            }
           
            var Result = _PlanServise.TogglePlan(id);
            if (Result)
            {
                TempData["SuccessMassage"] = "  Plan Status Changed ";
            }
            else
            {
                TempData["ErrorMassage"] = " Plan Feild To Change ";
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
