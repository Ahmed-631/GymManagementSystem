using GymManagementDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.DataSeeding
{
     public static class IdentityDbcontextSeeding
    {

        public static bool DataSeed(UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> roleManger)
        {

            try
            {
                var HasUsers = userManger.Users.Any();
                var HasRoles = roleManger.Roles.Any();
                if (HasUsers && HasRoles) return true;

                if (!HasRoles)
                {
                    var Roles = new List<IdentityRole>()
                    {
                        new() { Name = "SuperAdmin"} ,
                        new() { Name = "Admin"}
                    };

                    foreach (var Role in Roles)
                    {
                        if (!roleManger.RoleExistsAsync(Role.Name).Result)
                        {
                            roleManger.CreateAsync(Role).Wait();
                        }
                    }

                }

                if (!HasUsers)
                {
                    var MainAdmin = new ApplicationUser()
                    {
                        FirstName = "Ahmed"  , 
                         LastName = "Mohamed" , 
                         UserName = "AhmedMohamed" , 
                         Email = "AhmedMohamed@gmail.com" , 
                         PhoneNumber = "01127786751"
                    };

                    userManger.CreateAsync(MainAdmin, "P@ssw0rd").Wait();
                    userManger.AddToRoleAsync(MainAdmin, "SuperAdmin ").Wait();



                    var Admin = new ApplicationUser()
                    {
                        FirstName = "Aliaa",
                        LastName = "Tarek",
                        UserName = "AliaaTarik",
                        Email = "AliaaTarik@gmail.com",
                        PhoneNumber = "01009878182"
                    };

                    userManger.CreateAsync(Admin, "P@ssw0rd").Wait();
                    userManger.AddToRoleAsync(Admin, "Admin ").Wait();

                }
                return true; 
                
                
                }
           
            catch(Exception Ex ) 
            {
                Console.WriteLine(Ex); 
                return false;
            }

        
        
        }
    }
}
