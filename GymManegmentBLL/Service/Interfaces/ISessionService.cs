using GymManagementBLL.ViewModels.SessionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Interfaces
{
    public interface ISessionService
    {
        public IEnumerable<SessionViewModel> GetAllSessions(); 

        public SessionViewModel? GetSessionById (int SessionId);

        public bool CreateSession(CreateSessionViewModel CreatedSession);

        public UpdateSessionViewModel? GetSessionToUpdate(int SessionId);
        public bool UpdateSession(int SessionId, UpdateSessionViewModel UpdatedSession); 
    }
}
