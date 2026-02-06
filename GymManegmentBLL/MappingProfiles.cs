using AutoMapper;
using GymManagementBLL.ViewModels.SessionViewModels;
using GymManegementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL
{
    public class MappingProfiles :Profile
    {

        public MappingProfiles()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.TrainerName, options => options.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.CategoryName, options => options.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.AvailableSlots, options => options.Ignore());



            CreateMap<CreateSessionViewModel, Session>();

            CreateMap<Session, UpdateSessionViewModel>().ReverseMap(); 
               
            
        }


    }

      
}
