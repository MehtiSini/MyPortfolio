using InformationMangement.Infrastructure.EfCore.DbContextModel;
using MyQuery.Contracts.Person;
using MyQuery.Contracts.Skill;

namespace MyQuery.Query
{
    public class SkillQueryModel : ISkillQueryModel
    {

        private readonly PersonContext _personContext;
        public SkillQueryModel(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public List<SkillQueryViewModel> GetSkills()
        {
           return  _personContext.Skill.Where(x => x.PersonId == 1).Select(x => new SkillQueryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Percent = x.Percent,
                PersonId = x.PersonId,

            }).ToList();
        }
    }
}
