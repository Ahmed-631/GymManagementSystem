using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.TrainerViewModels
{
    public class TrainerToUpdateViewModel
    {

        public string? Name { get; set; } = null!;
        [Required(ErrorMessage =  "Email Is Required")]
        [EmailAddress(ErrorMessage ="In Valid Email Address")]
        [StringLength(100 , MinimumLength = 5)]

        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone  Is Requred")]
        [Phone(ErrorMessage = "In Valid Egyption Phone Number ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Specialties Is Required")]
        public Specialties Specialties { get; set; }
        [Required(ErrorMessage = "BuldingNumber is  Required")]
        [Range(1 , 1000)]
        public int BuldingNumber { get; set; }
        [Required(ErrorMessage = "City is  Required")]
      
        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "Street is  Required")]
        [StringLength(30, MinimumLength = 2)]
        public string Street { get; set; } = null!;
    }
}
