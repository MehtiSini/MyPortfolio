using InformationManagement.Contracts.Skill;
using InformationManagement.Domain.SkillsAgg;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools.Conversions;

namespace InformationMangement.Infrastructure.EfCore.Repository
{
    public class SkillRepository : RepositoryBase<long, SkillModel>, ISkillRepository
    {
        private readonly PersonContext _personContext;

        public SkillRepository(PersonContext personContext) : base(personContext)
        {
            _personContext = personContext;
        }

        public EditSkill GetDetails(long id)
        {
           return  _personContext.Skill.Select(x => new EditSkill
            {
                Id = x.Id,
                Name = x.Name,
                Percent = x.Percent,
                PersonId = x.PersonId
            }).FirstOrDefault(x => x.Id == id);

        }

        public List<SkillViewModel> GetSkills(long personId)
        {
            return _personContext.Skill.Where(x => x.PersonId == personId).Select(x => new SkillViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Percent = x.Percent,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();

        }
        public List<SkillViewModel> Search(SkillSearchModel SearchModel)
        {
            var Query = _personContext.Skill.Include(x => x.Person).Select(x => new SkillViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Percent = x.Percent,
                CreationDate = x.CreationDate.ToFarsi(),
                Person = x.Person.FullName
            });

            if (!string.IsNullOrEmpty(SearchModel.Name))
            {
                Query = Query.Where(x => x.Name == SearchModel.Name);
            }

            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
