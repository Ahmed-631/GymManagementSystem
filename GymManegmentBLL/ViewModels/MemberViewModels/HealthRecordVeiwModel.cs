using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.MemberViewModels
{
    public  class HealthRecordVeiwModel
    {
        [Required]
        [Range(0.1 , 300)]
        public decimal Height { get; set; }
        [Required]
        [Range(0.1, 500)]
        public decimal Weight { get; set; }

        [StringLength (3 )]
        public string BloodType { get; set; } = null!; 

        public string? Note { get; set; }
    }
}
