using InformationMangement.Infrastructure.EfCore.DbContextModel;
using MyFramework.Tools.Conversions;
using MyQuery.Contracts.Person;

namespace MyQuery.Query
{
    public class PersonQuery : IPersonQuery
    {
        private readonly PersonContext _personContext;
        public PersonQuery(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public PersonQueryViewModel GetInformation()
        {
            return _personContext.Person.Where(x => x.Id == 1).Select(x => new PersonQueryViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                PictureAlt = x.PictureAlt,
                ShortDescription = x.ShortDescription,
                Description=x.Description,
                PicturePath = x.PicturePath,
                Address = x.Address,
                Email = x.Email,
                Mobile = x.Mobile,

            }).FirstOrDefault(x => x.Id == 1);
        }
    }
}
