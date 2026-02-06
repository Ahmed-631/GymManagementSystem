using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.ViewModels.AnalitiecsViewModels
{
    public class AnalyticesViewModel
    {

        public int TotalMembers  { get; set; }
        public int ActiveMembers { get; set; }

        public int TotalTrainer { get; set; }


        public int OnGoingSessions { get; set; }

        public int UpCommingSessions  { get; set; }

        public int CompletedSessions { get; set; }
    }
}
