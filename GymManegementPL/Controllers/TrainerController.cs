using GymManagementBLL.Service.Classes;
using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerSarvice _TrainerSarvice;

        public TrainerController(ITrainerSarvice trainerSarvice)
        {
           _TrainerSarvice = trainerSarvice;
        }
        public IActionResult Index()
        {

            var Trainers = _TrainerSarvice.GetAllTrainers();
            return View(Trainers);
        }

        public IActionResult Create() 
        { 
         
            return View();


        
        }
        [HttpPost]
        public ActionResult CreateTrainer(CreateTrainerViewModel CreatedTrainer  ) 
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And The Missing Fields");
                return View("Create", CreatedTrainer);

            }

            bool result = _TrainerSarvice.CreateTrainer(CreatedTrainer);

            if (result)
            {
                TempData["SuccessMassage"] = "Trainer Created Successfully";
            }
            else
            {
                TempData["ErrorMassage"] = " Can Not Create This Trainer";
              
            }


                return RedirectToAction(nameof(Index));
        
        
        }


        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index));
            }
            var Trainer = _TrainerSarvice.GetTrainerToUpdate(id);
            if (Trainer is null)
            {
                TempData["ErrorMassage"] = " Trainer Not Found ";
                return RedirectToAction(nameof(Index));
            }

            return View(Trainer);



        }

        [HttpPost]
        public ActionResult Edit( [FromRoute] int id, TrainerToUpdateViewModel UpdatedTrainer)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Wrong Data", "In Valid Data ");
                return View(UpdatedTrainer); 
            }

            bool Result = _TrainerSarvice.UpdateTrainer( UpdatedTrainer , id);
            if (Result)
            
            {

                TempData["SuccessMassage"] = "  Trainer Update Successfully ";
            }
            else
            {
                TempData["ErrorMassage"] = " Trainer Feild To Update ";
            }
            return RedirectToAction(nameof(Index));



        }

        public ActionResult TrainerDetails(int id) 
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index));
            }
            var Trainer = _TrainerSarvice.GetTrainerDetails(id);
            if (Trainer is null)
            {
                TempData["ErrorMassage"] = " Trainer Not Found ";
                return RedirectToAction(nameof(Index));
            }

            return View(Trainer);
        
        }


        public ActionResult Delete  ( [FromRoute]int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = " The Id Can Not Be Zero Or Negative Number ";
                return RedirectToAction(nameof(Index)); 
            }
            var Trainer = _TrainerSarvice.GetTrainerDetails(id);
            if (Trainer is null)
            {
                TempData["ErrorMassage"] =  " Trainer Not Found ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrainerId = id; 
            return View(); 

        }


        public ActionResult DeleteConfirmed([FromForm] int id)
        {

            bool Result = _TrainerSarvice.RemoveTraner(id);
            if (Result)
            {
                TempData["SuccessMassage"] = " Delete Trainer Successfully ";
            }
            else 
            {
                TempData["ErrorMassage"] = " Trainer Feild To Delete ";
            }
            return RedirectToAction(nameof(Index));

         
        
        }

      



    }
}
