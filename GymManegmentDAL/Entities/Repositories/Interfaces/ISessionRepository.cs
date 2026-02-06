using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities.Repositories.Interfaces
{
    public  interface ISessionRepository : IGenericRepository<Session>
    {
        public IEnumerable<Session> GetAllSessionsWithTrainerAndCategory();


        public int GetCountOfBookingSlots( int SessionId); 


        public Session? GetSessionWithTrainerAndCategory (int SessionId);


    }
}
