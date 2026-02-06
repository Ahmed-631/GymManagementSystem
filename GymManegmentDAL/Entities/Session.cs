using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Entities
{
    public class Session : BaseEntity
    {

        public string Description { get; set; } = null!;

        public int Capacity { get; set; } 

        public DateTime StartDate { get; set; } 
        public DateTime EndDate     { get; set; }
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;


        public ICollection<MemberSession>? MemberSession { get; set; }

    }
}
