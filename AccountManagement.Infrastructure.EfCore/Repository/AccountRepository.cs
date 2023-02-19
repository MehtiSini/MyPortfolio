using AccountManagement.Contracts.AccountAgg;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EfCore.DbContextModel;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;
using MyFramework.Tools.Conversions;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, AccountModel>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext context) : base(context)
        {
            _accountContext = context;
        }

        public List<AccountViewModel> GetAccounts()
        {

            return _accountContext.Account.Select(x => new AccountViewModel
            {
                Id=x.Id,
                FullName=x.FullName,
                Username = x.Username,
                Mobile = x.Mobile,
                CreationDate=x.CreationDate.ToFarsi()

            }).ToList();
        }

        public AccountModel GetBy(string UserName)
        {
            return _accountContext.Account.FirstOrDefault(x => x.Username == UserName);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.Account.Select(x => new EditAccount
            {
                Id = x.Id,
                Username = x.Username,
                FullName = x.FullName,
                Mobile = x.Mobile,
                Password = x.Password
            }).First();

        }
    }
}
