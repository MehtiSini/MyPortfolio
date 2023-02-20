using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Areas.Administration.Pages.Person
{

    [Authorize]
    public class IndexModel : PageModel
    {
        public List<SkillViewModel> Skills;

        public PersonViewModel Command;

        private readonly ISkillApplication _skillApplication;

        private readonly IPersonAppliaction _personApplicaction;
        public IndexModel(IPersonAppliaction personApplicaction, ISkillApplication skillApplication)
        {
            _personApplicaction = personApplicaction;
            _skillApplication = skillApplication;
        }
        public void OnGet()
        {
            Command = _personApplicaction.GetInformation();
        }

        public IActionResult OnGetSkill(long PersonId)
        {
            Skills = _skillApplication.GetSkills(PersonId);

            return Partial("Skill", Skills);
        }
    }
}
