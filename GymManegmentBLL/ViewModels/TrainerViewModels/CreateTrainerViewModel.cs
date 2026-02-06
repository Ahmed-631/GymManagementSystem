using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.TrainerViewModels
{
    public class CreateTrainerViewModel
    {

        [Required (ErrorMessage = "Name is Requird")]
        [StringLength  (50 , MinimumLength = 2 )]
        [RegularExpression(@"^[a-zA-z\s]+$") ]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Requird")]
        [StringLength(100, MinimumLength = 5)]
        [EmailAddress]
    

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone  Is Requred")]
        [Phone(ErrorMessage = "In Valid Egyption Phone Number ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Specialties is Requird")]
        public Specialties Specialties { get; set; } 



        [Required]
        [Range(1, 1000)]
        public int BuildingNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-z\s]+$")]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Street { get; set; } = null!;

        [Required]
        [DataType (DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; } 
    }
}
