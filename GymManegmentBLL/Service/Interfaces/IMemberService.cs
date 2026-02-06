using GymManagementBLL.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Service.Interfaces
{
    public interface IMemberService
    {

        public IEnumerable<MemberVewModel> GetAllMembers();

        public bool CreateMember(CreatedMemberVeiwModel CreatedMember);


        public MemberVewModel? GetMemberDetails(int MemberId);

        public HealthRecordVeiwModel? GetMemberHealthRecord(int MemberId);

        public MembertoUpdateVeiwModel? GetMemberToUpdate(int MemberId); 

        public bool UpdateMember(MembertoUpdateVeiwModel MemberToUpdate  , int MemberId);

        public bool RemoveMember(int MemberId);






    }
}
