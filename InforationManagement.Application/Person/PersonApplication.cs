using Azure;
using InformationManagement.Contracts.Person;
using InformationManagement.Domain.PersonAgg;
using MyFramework.Tools.FileUploader;
using MyFramework.Tools.Operations;

namespace InformationManagement.Application.Person
{
    public class PersonApplication : IPersonAppliaction
    {
        private readonly IPersonRepository _personRepository;
        private readonly IFileUploader _fileUploader;
        public PersonApplication(IPersonRepository personRepository, IFileUploader fileUploader)
        {
            _personRepository = personRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreatePerson Cmd)
        {
            var operation = new OperationResult();

            if (_personRepository.Exist(x => x.FullName == Cmd.FullName))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Name = Cmd.FullName.Trim().Split(' ')[0];

            var PicturePath = _fileUploader.Upload(Cmd.PicturePath, Name);

            var Person = new PersonModel(Cmd.FullName, PicturePath, Cmd.Email, Cmd.Mobile, Cmd.ShortDescription,
                Cmd.IsFreelancer, Cmd.Address, Cmd.Description, Cmd.PictureAlt);

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

            var Name = Cmd.FullName.Trim().Split(' ')[0];

            var PicturePath = _fileUploader.Upload(Cmd.PicturePath, Name);

            Person.Edit(Cmd.FullName, PicturePath, Cmd.Email, Cmd.Mobile, Cmd.ShortDescription,
                Cmd.IsFreelancer, Cmd.Address, Cmd.Description, Cmd.PictureAlt);

            _personRepository.Save();

            return operation.Succeed();
        }


        public EditPerson GetDetails(long id)
        {
            return _personRepository.GetDetails(id);
        }

        public PersonViewModel GetInformation()
        {
            return _personRepository.GetInformation();
        }
    }
}
