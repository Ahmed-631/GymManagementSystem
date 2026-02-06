using AutoMapper;
using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.SessionViewModels;
using GymManagementDAL.UnitOfWork;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork  , IMapper Mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = Mapper;
        }

       

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var Sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategory();

            if (!Sessions.Any()) return [];



            var MappedSessions = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(Sessions);
            foreach (var Session in MappedSessions)

            {
                Session.AvailableSlots = Session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookingSlots(Session.Id);


            }

            return MappedSessions;




        }

     

        public SessionViewModel? GetSessionById(int SessionId)
        {
           var Session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(SessionId);

            if (Session == null) return null;

           

            var MappedSession = _mapper.Map<Session, SessionViewModel>(Session);

            MappedSession.AvailableSlots = MappedSession.Capacity - _unitOfWork.SessionRepository.GetCountOfBookingSlots(Session.Id);

            return MappedSession; 
        }

        public bool CreateSession(CreateSessionViewModel CreatedSession)

        {
            if (!IsTrainerExist(CreatedSession.TrainerId)) 
                return false; 
            if (!IsCategoeyExist(CreatedSession.CategoryId))
                return false; 
            if (!IsValidDate(CreatedSession.StartDate , CreatedSession.EndDate)) 
                return false;
            if (CreatedSession.Capacity > 25 || CreatedSession.Capacity < 0 )
                return false;


            var SessionEntity = _mapper.Map<CreateSessionViewModel, Session>(CreatedSession);

            _unitOfWork.SessionRepository.Add(SessionEntity);
            return _unitOfWork.SaveChanges() > 0; 


              
        }

        public UpdateSessionViewModel? GetSessionToUpdate(int SessionId)
        {
            var Session = _unitOfWork.GetRepository<Session>().GetById(SessionId); 
                if (Session is  null) return null;
            if (!IsSessionAvialbleToUpdate(Session)) return null;

            var SessionViewModel = _mapper.Map<Session, UpdateSessionViewModel>(Session);
            return SessionViewModel; 


        }

        public bool UpdateSession(int SessionId, UpdateSessionViewModel UpdatedSession)
        {
            var Session = _unitOfWork.SessionRepository.GetById(SessionId);
            if (Session is null) return false;
            if (!IsSessionAvialbleToUpdate(Session)) return false;
            if (!IsTrainerExist(UpdatedSession.TrainerId) || !IsValidDate(UpdatedSession.StartDate, UpdatedSession.EndDate)) return false;
            var SessionEntity = _mapper.Map<UpdateSessionViewModel , Session>(UpdatedSession);

            _unitOfWork.GetRepository<Session>().Update(SessionEntity); 
            return _unitOfWork.SaveChanges() > 0;
         }

        private bool IsTrainerExist(int TrainerId) 
        
        { return _unitOfWork.GetRepository<Trainer>().GetById(TrainerId) is not null;   }


        private bool IsCategoeyExist(int CategoryId)

        { return _unitOfWork.GetRepository<Category>().GetById(CategoryId) is not null; }


        private bool IsValidDate(DateTime Start, DateTime End) 
        
        { return Start < End; }

        private bool IsSessionAvialbleToUpdate(Session session) 
        {
            if (session.StartDate <= DateTime.Now) return false;


            if (session.EndDate < DateTime.Now) return false;  // ongoing 

            var HasActiveBooking = _unitOfWork.SessionRepository.GetCountOfBookingSlots(session.Id); 

            if (HasActiveBooking  > 0  ) return false; 

           else return true; 


        }




       

     
    }
}
