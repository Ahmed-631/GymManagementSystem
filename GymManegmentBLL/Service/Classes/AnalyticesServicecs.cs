using AutoMapper.Execution;
using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.AnalitiecsViewModels;
using GymManagementDAL.UnitOfWork;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Classes
{
    public class AnalyticesServicecs : IAnalytiecsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticesServicecs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnalyticesViewModel GetAnalyticesData()
        {

            var Sessions = _unitOfWork.GetRepository<Session>().GetAll();
            return new AnalyticesViewModel()
            {
                TotalMembers = _unitOfWork.GetRepository<GymManegementDAL.Entities.Member>().GetAll().Count(),
                TotalTrainer = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                ActiveMembers = _unitOfWork.GetRepository<MemberShip>().GetAll().Where(m => m.Status == "Active").Count(),
                UpCommingSessions = Sessions.Where(s => s.StartDate > DateTime.Now).Count() , 
                OnGoingSessions = Sessions.Where(s => s.StartDate < DateTime.Now && s.EndDate > DateTime.Now).Count(),
                CompletedSessions = Sessions.Where(s => s.EndDate <  DateTime.Now ).Count()  
              
            };   
        }
    }
}
