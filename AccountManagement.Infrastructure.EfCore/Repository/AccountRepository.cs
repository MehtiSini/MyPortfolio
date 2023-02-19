using AccountManagement.Contracts.AccountAgg;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using MyFramework.Infrastructure;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, AccountModel>, IAccountRepository
    {

        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public AccountModel GetBy(string UserName)
        {
            return _context.Account.FirstOrDefault(x => x.Username == UserName);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Account.Select(x => new EditAccount
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password

            }).FirstOrDefault(x => x.Id == id);

        }
    }
}
