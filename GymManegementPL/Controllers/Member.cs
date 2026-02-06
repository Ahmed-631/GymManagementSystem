using GymManagementBLL.Service.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementPL.Controllers
{
    public class Member : Controller
    {
        private readonly IMemberService _memberService;

        public Member(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {

            var Members = _memberService.GetAllMembers(); 
            return View(Members);
        }

        public ActionResult MemberDetails(int id)
        {
            if (id <= 0) {
                return RedirectToAction(nameof(Index));
            }

                var Member = _memberService.GetMemberDetails(id);
            if(Member is null ) {
                return RedirectToAction(nameof(Index));
            }

            return View(Member);    
        }


        public ActionResult HealthRecoedDetails(int id)
        { 
            if (id <= 0) 
            {
                TempData["Error Massage"] = "Member Id Can Not By Zero Or Negative ";
                return RedirectToAction(nameof(Index));
            }
                   
         var HealthRecord = _memberService.GetMemberHealthRecord(id);
         
            if(HealthRecord is null) 
            { 
                return RedirectToAction(nameof(Index));
            }
            return View(HealthRecord);
        
        }

        public ActionResult Create() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult CreateMember(CreatedMemberVeiwModel CreatedMember ) 
        {
             

            if (!ModelState.IsValid) 
            {

                ModelState.AddModelError("DataInValid" , "Check Data And The Missing Fields");
                
                return View(nameof(Create  ) , CreatedMember); 

            
            }  

              bool Result   =   _memberService.CreateMember(CreatedMember);
            if (Result)
            {
                TempData["Success Massage"] = "Member Created Successfully";
            }
            else 
            {
                TempData["Error Massage"] = "Member Filed To Create ";
            }
            return RedirectToAction(nameof(Index)); 
        
        }



        public ActionResult EditMember(int id)
        {
            if (id <= 0)
            {
                TempData["Error Massage"] = "Id Of Member Can Not Be Zero Or Negative ";
                return RedirectToAction(nameof(Index));
            }
            var MembetrView = _memberService.GetMemberToUpdate(id);
            if (MembetrView is null)
            {
                TempData["Error Massage"] = " Member Not Found  ";
                return RedirectToAction(nameof(Index));
            }
            return View(MembetrView); 
        
        
            
        }

        [HttpPost]
        public ActionResult EditMember(  MembertoUpdateVeiwModel EditMember  , [FromRoute]  int id)
        {

            if (!ModelState.IsValid) return View(EditMember);

              var Result = _memberService.UpdateMember(EditMember, id);

            if (Result)
            {
                TempData["Success Massage"] = "  Edit Member Successfully";
                return RedirectToAction(nameof(Index));

            }
            else 
            {
                TempData["Error Massage"] = "Member Filed To Update ";
                return RedirectToAction(nameof(Index));
            }



        }


        public ActionResult Delete(int id)
        {
            if (id <= 0) 
            {
                TempData["Error Massage"] = "Id Of Member Can Not Be Zero Or Negative ";
                return RedirectToAction(nameof(Index));
            }

            var Member = _memberService.GetMemberDetails(id);
            if (Member is null)
            {
                TempData["Error Massage"] = " Member Not Found  ";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MemberId = id;
            ViewBag.MemberName = Member.Name;
            return View();
        
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id) 
        { 
            var Result  = _memberService.RemoveMember(id);
            if (Result)
            {
                TempData["Success Massage"] = " Remove Member Successfully ";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error Massage"] = " Member Filed To Delete ";
                return RedirectToAction(nameof(Index));
            }
        
        
        }
    }

  
} 