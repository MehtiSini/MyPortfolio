using InformationManagement.Contracts.Person;
using MyFramework.Domain;

namespace InformationManagement.Domain.PersonAgg
{
    public interface IPersonRepository : IRepository<long,PersonModel>
    {
        EditPerson GetDetails(long id);
        List<PersonViewModel> GetAll();

    }
}
