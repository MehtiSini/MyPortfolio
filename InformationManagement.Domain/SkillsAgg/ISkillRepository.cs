using InformationManagement.Contracts.Skill;
using MyFramework.Domain;

namespace InformationManagement.Domain.SkillsAgg
{
    public interface ISkillRepository : IRepository<long, SkillModel>
    {
        EditSkill GetDetails(long id);
        List<SkillViewModel> Search(SkillSearchModel SearchModel);
        List<SkillViewModel> GetSkills(long personId);   
    }
}
