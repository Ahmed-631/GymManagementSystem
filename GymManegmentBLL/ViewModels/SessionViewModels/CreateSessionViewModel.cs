using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.SessionViewModels
{
    public class CreateSessionViewModel
    {
        [Required]
        [StringLength(500 , MinimumLength = 20 )]
        public string Description { get; set; } = null!;
        [Required]
        [Range(0 , 25)]
        public int Capacity { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]
        [Display( Name ="Trainer")]

        public int TrainerId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
