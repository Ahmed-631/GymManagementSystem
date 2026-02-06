using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModels
{
    public class MembertoUpdateVeiwModel
    {
         public string? Photo { set; get; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "max length is 50 Charcters")]
        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string Name { set; get; } = null!;

        [Required(ErrorMessage = "Email Is Requred")]
        [EmailAddress(ErrorMessage = "In Valid Email ")]
        [StringLength(100, MinimumLength = 5)]
        public string Email { set; get; } = null!;

        [Required(ErrorMessage = "Phone  Is Requred")]
        [Phone(ErrorMessage = "In Valid Egyption Phone Number ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string Phone { set; get; } = null!;

        [Required]
        [Range(1, 1000)]
        public int BuildingNumber { set; get; } 
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string City { set; get; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Street { set; get; } = null!;
    }
}
