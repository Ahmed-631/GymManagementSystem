using GymManagementBLL.ViewModels.PlanViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Interfaces
{
    public interface IplanService
    {
        public IEnumerable<PlanViewModel> GetAllPlans(); 

        public PlanViewModel? GetPlanById(int PlanId);

        public UpdatePlanViewModel? GetPlantoUpdate(int PlanId);

        public bool UpdatePlan(UpdatePlanViewModel UpdatedPlan, int PlanId);

        public bool TogglePlan(int PlanId); 



    }
}
