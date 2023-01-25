using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Areas.Administration.Pages.Person
{
    public class IndexModel : PageModel
    {
        public List<SkillViewModel> Skills;

        public List<PersonViewModel> Persons;

        private readonly ISkillApplication _skillApplication;

        private readonly IPersonAppliaction _personApplicaction;
        public IndexModel(IPersonAppliaction personApplicaction, ISkillApplication skillApplication)
        {
            _personApplicaction = personApplicaction;
            _skillApplication = skillApplication;
        }
        public void OnGet()
        {
            Persons = _personApplicaction.GetList();
        }

        public IActionResult OnGetCreate(CreatePerson Cmd)
        {
            return Partial("./Create", Cmd);
        }
        public IActionResult OnPostCreate(CreatePerson Cmd)
        {
            var Operation = _personApplicaction.Create(Cmd);

            return new JsonResult(Operation);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Result = _personApplicaction.GetDetails(id);

            return Partial("./Edit", Result);
        }
        public IActionResult OnPostEdit(EditPerson Cmd)
        {
            var Operation = _personApplicaction.Edit(Cmd);

            return new JsonResult(Operation);
        }

        public IActionResult OnGetSkill(long PersonId)
        {
            Skills = _skillApplication.GetSkills(PersonId);

            return Partial("Skill", Skills);
        }
    }
}
