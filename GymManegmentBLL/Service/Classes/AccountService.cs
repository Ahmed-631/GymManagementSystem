using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.AccountViewModels;
using GymManagementDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Classes
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _UserManger;

        public AccountService(UserManager<ApplicationUser> UserManger)
        {
            _UserManger = UserManger;
        }
        public ApplicationUser? ValidateUser(LoginViewModel LoginVoewModel)
        {
            var User = _UserManger.FindByEmailAsync(LoginVoewModel.Email).Result;
            if (User == null)  return null;
            var IsPasswordValid = _UserManger.CheckPasswordAsync(User, LoginVoewModel.Password).Result; 
            return IsPasswordValid ? User : null;
        }
    }
}
