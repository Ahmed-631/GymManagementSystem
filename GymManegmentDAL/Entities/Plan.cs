using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Entities
{
    public class Plan : BaseEntity
    {

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<MemberShip>? PlanMembers { get; set; } = null!;


    }
}
