using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.PlanViewModels
{
    public class UpdatePlanViewModel
    {
        [Required(ErrorMessage = "Plan Name is Required")]
        [StringLength (50 )]
        public string PlanName { get; set; } = null!;



        [Required(ErrorMessage = "Discription  is Required")]
        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "DurationDays is Required")]
        [Range (1 , 365)]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [Range(0.1, 10000)]
        public decimal Price { get; set; } 
    }
}
