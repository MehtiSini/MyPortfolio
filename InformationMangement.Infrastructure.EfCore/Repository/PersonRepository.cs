using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using InformationManagement.Domain.PersonAgg;
using InformationManagement.Domain.SkillsAgg;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools.Conversions;

namespace InformationMangement.Infrastructure.EfCore.Repository
{
    public class PersonRepository : RepositoryBase<long, PersonModel>, IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context) : base(context)
        {
            _context = context;
        }

        public PersonViewModel GetInformation()
        {
            return _context.Person.Include(x => x.Skills).Select(x => new PersonViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                PictureAlt = x.PictureAlt,
                ShortDescription = x.ShortDescription,
                IsFreelancer = x.IsFreelancer,
                CreationDate = x.CreationDate.ToFarsi(),
                PicturePath = x.PicturePath,
                Address = x.Address,
                Email = x.Email,
                Mobile = x.Mobile,
                Skills = MapSkills(x.Skills)
            }).AsNoTracking().First();
        }

        private static List<SkillViewModel> MapSkills(List<SkillModel> skills)
        {
            return skills.Select(x => new SkillViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Percent = x.Percent,
            }).ToList();
        }

        public EditPerson GetDetails(long id)
        {
            return _context.Person.Select(x => new EditPerson
            {
                Id = x.Id,
                FullName = x.FullName,
                ShortDescription = x.ShortDescription,
                PictureAlt = x.PictureAlt,
                Description = x.Description,
                IsFreelancer = x.IsFreelancer,
                Address = x.Address,
                Email = x.Email,
                Mobile = x.Mobile

            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
