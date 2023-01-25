using InformationManagement.Contracts.Person;

namespace InformationManagement.Contracts.Skill
{
    public class CreateSkill
    {
        public string? Name { get; set; }
        public int Percent { get; set; }
        public long PersonId { get;  set; }
        public List<PersonViewModel>? People { get;  set; }
    }

}
