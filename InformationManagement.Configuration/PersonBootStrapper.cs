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
using MyQuery.Contracts.Person;
using MyQuery.Contracts.Skill;
using MyQuery.Query;

namespace InformationManagement.Configuration
{
    public class PersonBootStrapper
    {
        public void Configure(IServiceCollection services, string ConnString)
        {
            services.AddTransient<IPersonAppliaction, PersonApplication>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<ISkillApplication, SkillApplication>();
            services.AddTransient<ISkillRepository, SkillRepository>();

            services.AddTransient<IPersonQuery, PersonQuery>();
            services.AddTransient<ISkillQueryModel, SkillQueryModel>();

            services.AddDbContext<PersonContext>(x => x.UseSqlServer(ConnString));
        }
    }
}