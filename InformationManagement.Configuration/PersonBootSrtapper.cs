using InformationManagement.Application.Person;
using InformationManagement.Application.Skill;
using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using InformationManagement.Domain.PersonAgg;
using InformationManagement.Domain.SkillsAgg;
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

            services.AddTransient<ISkillApplication, SkillApplication>();
            services.AddTransient<ISkillRepository, SkillRepository>();

            services.AddDbContext<PersonContext>(x => x.UseSqlServer(ConnString));
        }
    }
}