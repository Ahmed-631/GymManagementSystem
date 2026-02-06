using GymManagementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Entities
{
    public class Trainer : GymUser
    {
        public Specialties Specialties { get; set; }
        // reuse createdat as a hiring date 
        public ICollection<Session>? sessions { get; set; } = new List<Session>(); 

    }
}
