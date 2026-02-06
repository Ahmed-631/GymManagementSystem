using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.TrainerViewModels;
using GymManagementDAL.UnitOfWork;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Classes
{


    public class TrainerSarvice : ITrainerSarvice
    {

        private readonly IUnitOfWork _UnitOfWork;


        public TrainerSarvice(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

      

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var Trainers = _UnitOfWork.GetRepository<Trainer>().GetAll();
            if (Trainers is null || !Trainers.Any()) 
                return Enumerable.Empty<TrainerViewModel>();

            var TrainerViewMoel =  Trainers.Select(T => new TrainerViewModel()
            {
                Id = T.Id,
                Email = T.Email,
                Name = T.Name,
                Phone = T.Phone,
                Specialties = T.Specialties.ToString() , 
          
                
            });

            return TrainerViewMoel; 
        }


        public bool CreateTrainer(CreateTrainerViewModel TrainerViewMOdel)
        {
            bool EmailIsExist = _UnitOfWork.GetRepository<Trainer>().GetAll().Where(t => t.Email == TrainerViewMOdel.Email).Any();

            bool PhoneIsExist = _UnitOfWork.GetRepository<Trainer>().GetAll().Where(t => t.Phone == TrainerViewMOdel.Phone).Any();

            if (EmailIsExist || PhoneIsExist) return false;
            var Trainer = new Trainer()
            {
                Name = TrainerViewMOdel.Name,
                Email = TrainerViewMOdel.Email,
                Phone = TrainerViewMOdel.Phone,
                Address = new Address()
                {
                    BuildingNumber = TrainerViewMOdel.BuildingNumber,
                    City = TrainerViewMOdel.City,
                    Street = TrainerViewMOdel.Street
                },
                DateOfBirth = TrainerViewMOdel.DateOfBirth,
                Specialties = TrainerViewMOdel.Specialties,
                Gender = TrainerViewMOdel.Gender,
                CreatedAt = DateTime.Now


            };
            _UnitOfWork.GetRepository<Trainer>().Add(Trainer);
            return _UnitOfWork.SaveChanges() > 0;
        }

        public TrainerDetailsViewModel? GetTrainerDetails(int TrainerId)
        {
                 var Trainer =  _UnitOfWork.GetRepository<Trainer>().GetById(TrainerId);

                  if(Trainer is null )   return null;

            return new TrainerDetailsViewModel()
            {
                Name = Trainer.Name,
                Email = Trainer.Email,
                Phone = Trainer.Phone,
                Address = $"{Trainer.Address.BuildingNumber} _ {Trainer.Address.City} _ {Trainer.Address.Street}",
                DateOfBirth = Trainer.DateOfBirth.ToShortDateString(),
                 Specialties = Trainer.Specialties.ToString(),

            }; 

        }

        public TrainerToUpdateViewModel? GetTrainerToUpdate(int TrainerId)
        {
            var Trainer = _UnitOfWork.GetRepository<Trainer>().GetById(TrainerId); 

            if(Trainer is null ) return null;

            return new TrainerToUpdateViewModel()
            {
                Name = Trainer.Name,
                Email = Trainer.Email,
                Phone = Trainer.Phone,
                Specialties = Trainer.Specialties,
                City = Trainer.Address.City,
                Street = Trainer.Address.Street,
                BuldingNumber = Trainer.Address.BuildingNumber,





            }; 
        }

        public bool UpdateTrainer(TrainerToUpdateViewModel UpdatedTraner, int TrainerId)
        {
            bool EmailExist = _UnitOfWork.GetRepository<Trainer>().GetAll().Where(t => t.Email == UpdatedTraner.Email && t.Id != TrainerId).Any();
            bool PhoneExist = _UnitOfWork.GetRepository<Trainer>().GetAll().Where(t => t.Phone == UpdatedTraner.Phone && t.Id != TrainerId).Any();

            if (EmailExist || PhoneExist)  return false;

            var Trainer = _UnitOfWork.GetRepository<Trainer>().GetById(TrainerId); 
            if (Trainer is null ) return false;
            Trainer.Email = UpdatedTraner.Email;
            Trainer.Phone = UpdatedTraner.Phone;
            Trainer.UpdatedAt = DateTime.Now;
            Trainer.Address.BuildingNumber = UpdatedTraner.BuldingNumber;
            Trainer.Address.Street = UpdatedTraner.Street;
            Trainer.Address.City = UpdatedTraner.City;
            Trainer.Specialties = UpdatedTraner.Specialties;




            _UnitOfWork.GetRepository<Trainer>().Update(Trainer);
            return _UnitOfWork.SaveChanges() > 0;




        }

        public bool RemoveTraner(int TrainerId) // Connot remove a trainer with future session 
        {
            bool HasFutureSession = _UnitOfWork.GetRepository<Session>().GetAll().Where(s => s.TrainerId == TrainerId &&
            s.StartDate > DateTime.Now).Any();
            var Trainer = _UnitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (HasFutureSession || Trainer is null) return false;

          
            _UnitOfWork.GetRepository<Trainer>().Delete(Trainer); 
            return _UnitOfWork.SaveChanges() > 0 ;       
        }
    }
}