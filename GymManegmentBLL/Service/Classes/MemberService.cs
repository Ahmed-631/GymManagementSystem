using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using GymManagementDAL.Entities.Repositories.Interfaces;
using GymManagementDAL.Entities.Repositories.Classes;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.UnitOfWork;

namespace GymManagementBLL.Service.Classes
{
    public class MemberService : IMemberService
    {



    
        private readonly IUnitOfWork _UnitOfWork;

        public MemberService( IUnitOfWork UnitOfWork )
         
        {

            _UnitOfWork = UnitOfWork; 
         
        }

      

        public IEnumerable<MemberVewModel> GetAllMembers()
        {
            var members = _UnitOfWork.GetRepository<Member>().GetAll();

              var MemberViewMode = members.Select(M => new MemberVewModel()
            {
                Id = M.Id,
                Name = M.Name,
                Email = M.Email,
                Phone = M.Phone,
                Photo = M.Photo,
                Gender = M.Gender.ToString()



            });

            return MemberViewMode; 
        }

        public bool CreateMember(CreatedMemberVeiwModel CreatedMember)
        {

            bool EmailExist = _UnitOfWork.GetRepository<Member>().GetAll().Where(m => m.Email == CreatedMember.Email).Any();


            bool PhoneExist = _UnitOfWork.GetRepository<Member>().GetAll().Where(m => m.Phone == CreatedMember.Phone).Any();
            if (EmailExist || PhoneExist) { return false; }

            var Member = new Member()
            {
                Name = CreatedMember.Name,
                Email = CreatedMember.Email,
                Phone = CreatedMember.Phone,
                DateOfBirth = CreatedMember.DateOfBirth,
                Gender = CreatedMember.Gender,
                Address = new Address()
                {
                    BuildingNumber = CreatedMember.BuildingNumber,
                    City = CreatedMember.City,
                    Street = CreatedMember.Street
                },

                HealthRecord = new HealthRecord()
                {
                    Height = CreatedMember.HealthRecordVeiwModel.Height,
                    Weight = CreatedMember.HealthRecordVeiwModel.Weight,
                    BloodType = CreatedMember.HealthRecordVeiwModel.BloodType,
                    Note = CreatedMember.HealthRecordVeiwModel.Note
                }



            };


            _UnitOfWork.GetRepository<Member>().Add(Member) ;
            return _UnitOfWork.SaveChanges() > 0 ; 



        }

        public MemberVewModel? GetMemberDetails(int MemberId)     
        {
            var Member = _UnitOfWork.GetRepository<Member>().GetById(MemberId); 
            if (Member is null)  return null;
            var MemberShip = _UnitOfWork.GetRepository<MemberShip>().GetAll()
                .Where(sh => sh.MemberId == MemberId && sh.Status == "Active")
                .FirstOrDefault() ;

         


          var MemberVewModel  = new MemberVewModel()

          {
                Name = Member.Name,
                Photo = Member.Photo,
                DateOfBirth = Member.DateOfBirth.ToString(),
                Phone = Member.Phone,
                Email = Member.Email,
                Gender = Member.Gender.ToString(),
                Address = $"{Member.Address.BuildingNumber} - {Member.Address.City} - {Member.Address.Street}",
   
          };

            if (MemberShip is not null) 
            {
                var plan = _UnitOfWork.GetRepository<Plan>().GetById(MemberShip.PlanId);
                MemberVewModel.MemberShipStartDate = MemberShip.CreatedAt.ToShortDateString();
                MemberVewModel.MemberShipEndDate = MemberShip.EndDate.ToShortDateString();
                MemberVewModel.PlanName = plan?.Name;
            }


            return MemberVewModel;



        }

        public HealthRecordVeiwModel? GetMemberHealthRecord(int MemberId)
        {
         
            var HealthRecoer = _UnitOfWork.GetRepository<HealthRecord>().GetById(MemberId);
            if (HealthRecoer is null) return null;

            return new HealthRecordVeiwModel()
            {
                Height = HealthRecoer.Height , 
                Weight = HealthRecoer.Weight ,
                BloodType = HealthRecoer.BloodType ,
                Note = HealthRecoer.Note 
            }; 






        }

        public MembertoUpdateVeiwModel? GetMemberToUpdate(int MemberId)
        {
           var Member = _UnitOfWork.GetRepository<Member>().GetById(MemberId);
            if(Member is null) return null;

            return new MembertoUpdateVeiwModel()
            {
                Name = Member.Name,
                Photo = Member.Photo,
                Email= Member.Email,
                Phone = Member.Phone,
                BuildingNumber = Member.Address.BuildingNumber , 
                City = Member.Address.City , 
                Street = Member.Address.Street ,
                
            
            };
        }

        public bool UpdateMember(MembertoUpdateVeiwModel MemberToUpdate, int MemberId)
        {
            bool EmailExist = _UnitOfWork.GetRepository<Member>()
                .GetAll()
                .Where(m => m.Email == MemberToUpdate.Email && m.Id != MemberId).Any();
            bool PhoneExist = _UnitOfWork.GetRepository<Member>().GetAll()
                .Where(m => m.Phone == MemberToUpdate.Phone && m.Id != MemberId).Any();
            if(EmailExist || PhoneExist) return false;


            var Member = _UnitOfWork.GetRepository<Member>().GetById(MemberId); 
            if(Member is null) return false;

            Member.Email = MemberToUpdate.Email;
            Member.Phone = MemberToUpdate.Phone;
            Member.UpdatedAt = DateTime.Now;
            Member.Address.BuildingNumber = MemberToUpdate.BuildingNumber;
            Member.Address.City = MemberToUpdate.City;
            Member.Address.Street = MemberToUpdate.Street; 
             

             _UnitOfWork.GetRepository<Member>().Update(Member)  ;
            return _UnitOfWork.SaveChanges() > 0;
        }

        public bool RemoveMember(int MemberId)
        {
            var Member = _UnitOfWork.GetRepository<Member>().GetById(MemberId);
            if(Member is null) return false;
            var HasActiveMemberSesssion = _UnitOfWork.GetRepository<MemberSession>().GetAll()
                 .Where(MS => MS.MemberId == MemberId && MS.Session.StartDate > DateTime.Now).Any(); 
            if (HasActiveMemberSesssion ) return false;

            var MemberShip = _UnitOfWork.GetRepository<MemberShip>().GetAll().Where(m => m.MemberId == MemberId);


                
            if (MemberShip.Any())
            {
                foreach (var item in MemberShip)
                {
                    _UnitOfWork.GetRepository<MemberShip>().Delete(item); 
                    
                }


            }

            _UnitOfWork.GetRepository<Member>().Delete(Member) ;
            return _UnitOfWork.SaveChanges() > 0; 

          

        }


    }
}

 