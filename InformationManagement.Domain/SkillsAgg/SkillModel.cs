using InformationManagement.Domain.PersonAgg;
using System;

namespace InformationManagement.Domain.SkillsAgg
{
    public class SkillModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Percent { get; set; }
        public DateTime CreationDate { get; private set; }
        public PersonModel? Person { get; private set; }
        public long PersonId { get; private set; }

        public SkillModel(string? name, int percent, long personId)
        {
            Name = name;
            Percent = percent;
            PersonId = personId;
            CreationDate = DateTime.Now;
        }

        public void Edit(string? name, int percent, long personId)
        {
            Name = name;
            Percent = percent;
            PersonId = personId;
        }
    }
}
