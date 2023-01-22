using InformationManagement.Application.Person;
using InformationManagement.Contracts.Person;
using InformationManagement.Domain.PersonAgg;
using InformationMangement.Infrastructure.EfCore.DbContextModel;
using InformationMangement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InformationManagement.Configuration
{
    public class PersonBootSrtapper
    {
        public void Configure(IServiceCollection services, string ConnString)
        {
            services.AddTransient<IPersonAppliaction, PersonApplication>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddDbContext<PersonContext>(x => x.UseSqlServer(ConnString));
        }
    }
}