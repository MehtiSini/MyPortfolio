using MyFramework.Tools.Operations;

namespace InformationManagement.Contracts.Person
{
    public interface IPersonAppliaction
    {
        OperationResult Create(CreatePerson Cmd);
        OperationResult Edit(EditPerson Cmd);
        EditPerson GetDetails(long id);
        List<PersonViewModel> GetList();
    }

}
