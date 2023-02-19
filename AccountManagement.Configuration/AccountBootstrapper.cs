using AccountManagement.Application.Account;
using AccountManagement.Contracts.AccountAgg;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EfCore.DbContextModel;
using AccountManagement.Infrastructure.EfCore.Repository;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InformationManagement.Configuration
{
    public class AccountBootstrapper
    {
        public void Configure(IServiceCollection services, string ConnString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(ConnString));
        }
    }
}