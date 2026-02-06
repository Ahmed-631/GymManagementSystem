using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModels
{
    public class CreatedMemberVeiwModel
    {
        [Required(ErrorMessage = "Name Is Requred")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "max length is 50 Charcters")]
        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Email Is Requred")]
        [EmailAddress(ErrorMessage = "In Valid Email ")]
        [StringLength(100, MinimumLength = 5)]

        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone  Is Requred")]
        [Phone(ErrorMessage = "In Valid Egyption Phone Number ")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]


        public string Phone { get; set; } = null!; 

        [Required]
        public Gender Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [Range(1, 1000)]
        public int BuildingNumber { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Street { get; set; } = null!;

        public HealthRecordVeiwModel HealthRecordVeiwModel { get; set; } = null!; 




}
}
