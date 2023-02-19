using MyFramework.Tools.Operations;

namespace AccountManagement.Contracts.AccountAgg
{
    public interface IAccountApplication
    {
        OperationResult Register(RegisterAccount cmd);
        OperationResult Login(LoginAccount Cmd);
        OperationResult Edit(EditAccount Cmd);
        OperationResult ChangePassword(ChangePassword Cmd);

        void SignOut();
        EditAccount GetDetails(long id);
    }
}
