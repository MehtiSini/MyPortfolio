using Microsoft.AspNetCore.Mvc;
using MyQuery.Contracts.Skill;

namespace MyPortfolio.Pages.ViewComponents
{
    public class SkillViewComponent : ViewComponent
    {

        private readonly ISkillQueryModel _skillQueryModel;

        public SkillViewComponent(ISkillQueryModel skillQueryModel)
        {
            _skillQueryModel = skillQueryModel;
        }

        public List<SkillQueryViewModel> Skills;
        public IViewComponentResult Invoke()
        {
            Skills = _skillQueryModel.GetSkills();

            return View(Skills);
        }
    }
}
