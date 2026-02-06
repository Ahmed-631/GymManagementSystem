using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.PlanViewModels;
using GymManagementDAL.UnitOfWork;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Classes
{
    public class PlanService : IplanService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PlanService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
          
        }
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var Plans = _UnitOfWork.GetRepository<Plan>().GetAll();
            if ( Plans is null || !Plans.Any() )
                return Enumerable.Empty<PlanViewModel>(); 

            var PlansViewModel = Plans.Select(p => new PlanViewModel()
            { 
            Id = p.Id , 
            Name = p.Name , 
            Description = p.Description , 
            DurationDays = p.DurationDays , 
            Price = p.Price , 
            IsActive = p.IsActive ,
            });

            return PlansViewModel; 

        }

        public PlanViewModel? GetPlanById(int PlanId)
        {
            var plan = _UnitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plan is  null) return null;
            return new PlanViewModel()
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
                IsActive = plan.IsActive,
            }; 
        }

        public UpdatePlanViewModel? GetPlantoUpdate(int PlanId)
        {
           
           
            var plan = _UnitOfWork.GetRepository<Plan>().GetById(PlanId); 
            if (plan is null || plan.IsActive == false  || HasActiveMemberShips(PlanId)) return null;

            return new UpdatePlanViewModel()
            {
                PlanName = plan.Name , 
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price
            }; 
            
        }
        public bool UpdatePlan(UpdatePlanViewModel UpdatedPlan, int PlanId)
        {
            var plan = _UnitOfWork.GetRepository<Plan>().GetById(PlanId);
            if(plan is null || HasActiveMemberShips(PlanId) ) return false;
            (plan.Description, plan.Price, plan.DurationDays, plan.UpdatedAt)
                = (UpdatedPlan.Description, UpdatedPlan.Price, UpdatedPlan.DurationDays, DateTime.Now);

            _UnitOfWork.GetRepository<Plan>().Update(plan);
            return _UnitOfWork.SaveChanges() > 0;
             
        }

        public bool TogglePlan(int PlanId) // softDelete == Update
        {
            var plan = _UnitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plan is null || HasActiveMemberShips(PlanId)) return false; 
            plan.IsActive =  plan.IsActive ==  true ?  false : true;
            plan.UpdatedAt = DateTime.Now; 
            _UnitOfWork.GetRepository<Plan>().Update(plan);
            return _UnitOfWork.SaveChanges() > 0;
        }

        private  bool HasActiveMemberShips(int PlanId)
        { 
           
            var HasActiveMemberShips = _UnitOfWork.GetRepository<MemberShip>().GetAll().Where(sh => sh.PlanId == PlanId && sh.Status == "Active"); 

        return HasActiveMemberShips.Any();


        }
       
    }
}
