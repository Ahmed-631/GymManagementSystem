using GymManagementBLL.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Interfaces
{
    public interface ITrainerSarvice
    {
        public IEnumerable<TrainerViewModel> GetAllTrainers();

        public bool CreateTrainer(CreateTrainerViewModel TrainerViewMOdel);

        public TrainerDetailsViewModel? GetTrainerDetails(int TrainerId);

        public TrainerToUpdateViewModel? GetTrainerToUpdate(int TrainerId);

        public bool UpdateTrainer(TrainerToUpdateViewModel UpdatedTraner , int TrainerId);

        public bool RemoveTraner(int TrainerId);


    }
}
