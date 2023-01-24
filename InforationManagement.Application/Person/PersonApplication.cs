using Azure;
using InformationManagement.Contracts.Person;
using InformationManagement.Domain.PersonAgg;
using MyFramework.Tools.Operations;

namespace InformationManagement.Application.Person
{
    public class PersonApplication : IPersonAppliaction
    {
        private readonly IPersonRepository _personRepository;
        public PersonApplication(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public OperationResult Create(CreatePerson Cmd)
        {
            var operation = new OperationResult();

            if (_personRepository.Exist(x => x.FullName == Cmd.FullName))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Person = new PersonModel(Cmd.FullName, "Picture", Cmd.Email, Cmd.Mobile, Cmd.ShortDescription,
                Cmd.IsFreelancer, Cmd.Address, Cmd.Description , Cmd.PictureAlt);

            _personRepository.Create(Person);

            _personRepository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditPerson Cmd)
        {
            var operation = new OperationResult();

            var Person = _personRepository.GetById(Cmd.Id);

            if (Person is null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (_personRepository.Exist(x => x.FullName == Cmd.FullName && x.Id != Cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            Person.Edit(Cmd.FullName, "Picture", Cmd.Email, Cmd.Mobile, Cmd.ShortDescription,
                Cmd.IsFreelancer, Cmd.Address, Cmd.Description, Cmd.PictureAlt);

            _personRepository.Save();

            return operation.Succeed();
        }

        public List<PersonViewModel> GetList()
        {
            return _personRepository.GetList();
        }

        public EditPerson GetDetails(long id)
        {
            return _personRepository.GetDetails(id);
        }
    }
}
