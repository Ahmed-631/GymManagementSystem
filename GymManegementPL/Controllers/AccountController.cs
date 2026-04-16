using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.AccountViewModels;
using GymManagementDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GymManagementPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _AccountService;
        private readonly SignInManager<ApplicationUser> _SignInManger;

        public AccountController(IAccountService AccountService  , SignInManager<ApplicationUser>  SignInManger)
        {
            _AccountService = AccountService;
            _SignInManger = SignInManger;
        }
        public IActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel Model )
        {
             if (!ModelState.IsValid) return View(Model);
              
              var User   =  _AccountService.ValidateUser(Model);
            if (User is null)
            {
                ModelState.AddModelError("InvalidLogin", "InValid Email Or Password");
                return View(Model);
                    
            }

            var Result = _SignInManger.PasswordSignInAsync(User, Model.Password, Model.RememberMe, false).Result;

            if (Result.IsNotAllowed)
                ModelState.AddModelError("InvalidLogin", "Your Account Is Not Allowed");


            if (Result.IsLockedOut)
                ModelState.AddModelError("InvalidLogin", "Your Account LockedOut");

            if (Result.Succeeded)
                return RedirectToAction("Index", "Home"); 


            return View(Model);


        }


        public ActionResult Logout() 
        {
            _SignInManger.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Login)); 
        }


        public ActionResult AccessDenied()
        { 
            return View();
        }
    }
}
