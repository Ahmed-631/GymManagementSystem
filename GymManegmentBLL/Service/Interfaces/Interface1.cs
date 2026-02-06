using GymManagementBLL.ViewModels.AnalitiecsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Interfaces
{
    public interface  IAnalytiecsService
    {

        public AnalyticesViewModel GetAnalyticesData(); 
     }
}
