using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.SessionViewModels
{
    public class UpdateSessionViewModel
    {
        [Required]
        [Display(Name = "Trainer")]
     
        public int TrainerId { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; } = null!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
    }
}
