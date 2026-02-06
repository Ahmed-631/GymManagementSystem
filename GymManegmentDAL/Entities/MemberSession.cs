using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManegementDAL.Entities
{
    public class MemberSession : BaseEntity
    {
        public Member Member { get; set; } = null!;
        public int MemberId { get; set; }
        public Session  Session { get; set; } = null!;
        public int SessionId { get; set; }
        public bool IsAttended { get; set; }

        // bookingday == created AT
    }
}
