using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyPortfolio.Areas.Administration.Pages.Skill
{
    public class IndexModel : PageModel
    {
        public SkillSearchModel SearchModel;
        public List<SkillViewModel> Skills;

        private readonly IPersonAppliaction _personApplication;
        private readonly ISkillApplication _skillApplication;

        public IndexModel(ISkillApplication skillApplication, IPersonAppliaction personApplication)
        {
            _skillApplication = skillApplication;
            _personApplication = personApplication;
        }
        public void OnGet(SkillSearchModel searchModel)
        {
            Skills = _skillApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var Command = new CreateSkill();
           
            return Partial("./Create", Command);
        }
        public IActionResult OnPostCreate(CreateSkill Cmd)
        {
            var result = _skillApplication.Create(Cmd);

            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Result = _skillApplication.GetDetails(id);

            return Partial("./Edit", Result);
        }
        public IActionResult OnPostEdit(EditSkill Cmd)
        {
            var result = _skillApplication.Edit(Cmd);

            return new JsonResult(result);
        }
    }
}
