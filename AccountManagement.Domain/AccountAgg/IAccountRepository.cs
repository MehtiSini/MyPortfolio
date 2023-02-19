using AccountManagement.Contracts.AccountAgg;
using MyFramework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long,AccountModel>
    {
        List<AccountViewModel> GetAccounts();
        EditAccount GetDetails(long id);
        AccountModel GetBy(string UserName);
    }
}
