using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.TrainerViewModels
{
    public class TrainerDetailsViewModel
    {
        public string Email { get; set; } = null!; 
     
        public string Name { get; set; } = null!;
        public string Phone  { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Specialties { get; set; } = null!;


    }
}
