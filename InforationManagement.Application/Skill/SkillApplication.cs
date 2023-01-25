using InformationManagement.Contracts.Skill;
using InformationManagement.Domain.PersonAgg;
using InformationManagement.Domain.SkillsAgg;
using MyFramework.Tools.FileUploader;
using MyFramework.Tools.Operations;

namespace InformationManagement.Application.Skill
{
    public class SkillApplication : ISkillApplication
    {
        private readonly ISkillRepository _skilLRepository;

        public SkillApplication(ISkillRepository skilLRepository)
        {
            _skilLRepository = skilLRepository;
        }

        public OperationResult Create(CreateSkill Cmd)
        {
            var operation = new OperationResult();

            if (_skilLRepository.Exist(x => x.Name == Cmd.Name))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Skill = new SkillModel(Cmd.Name,Cmd.Percent,Cmd.PersonId);

            _skilLRepository.Create(Skill);

            _skilLRepository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditSkill Cmd)
        {
            var operation = new OperationResult();

            var Skill = _skilLRepository.GetById(Cmd.Id);

            if (Skill is null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (_skilLRepository.Exist(x => x.Name == Cmd.Name && x.Id != Cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            Skill.Edit(Cmd.Name, Cmd.Percent, Cmd.PersonId);

            _skilLRepository.Save();

            return operation.Succeed();
        }

        public EditSkill GetDetails(long id)
        {
            return _skilLRepository.GetDetails(id);
        }

        public List<SkillViewModel> GetSkills(long personId)
        {
            return _skilLRepository.GetSkills(personId);
        }

        public List<SkillViewModel> Search(SkillSearchModel SearchModel)
        {
            return _skilLRepository.Search(SearchModel);
        }
    }
}
