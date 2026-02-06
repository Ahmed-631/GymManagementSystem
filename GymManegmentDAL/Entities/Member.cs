using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Entities
{
    public class Member : GymUser
    {

        public HealthRecord HealthRecord { get; set; } = null!;  
        public string? Photo {set ;get;}
        public ICollection<MemberSession>? MemberSession { get; set; } = new List<MemberSession>();


        public ICollection<MemberShip>? MemberPlans { get; set; } = new List<MemberShip>();
    }
}
