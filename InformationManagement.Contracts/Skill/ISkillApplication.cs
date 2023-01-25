using MyFramework.Tools.Operations;

namespace InformationManagement.Contracts.Skill
{
    public interface ISkillApplication
    {
        OperationResult Create(CreateSkill Cmd);
        OperationResult Edit(EditSkill Cmd);
        EditSkill GetDetails(long id);
        List<SkillViewModel> Search(SkillSearchModel SearchModel);
        List<SkillViewModel> GetSkills(long personId);
    }
}
