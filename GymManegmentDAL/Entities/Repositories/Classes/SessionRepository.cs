using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManegementDAL.Data.Context;
using GymManegementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities.Repositories.Classes
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDbcontext _dbcontext;

        public SessionRepository(GymDbcontext dbcontext ):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<Session> GetAllSessionsWithTrainerAndCategory()
        {
             return _dbcontext.Sessions.Include(s => s.Trainer)
                .Include(s => s.Category)
                .ToList();
               
        }

        public int GetCountOfBookingSlots(int SessionId)
        {
            return _dbcontext.MemberSessions.Count(m => m.SessionId == SessionId); 
        }

        public Session? GetSessionWithTrainerAndCategory(int SessionId)
        {
            return _dbcontext.Sessions.Include(s => s.Trainer).Include(s => s.Category).FirstOrDefault(s => s.Id == SessionId); 
        }
    }
}
