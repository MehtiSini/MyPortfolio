using InformationManagement.Domain.PersonAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace InformationMangement.Infrastructure.EfCore.DbContextModel
{
    public class PersonContext : DbContext
    {
        public DbSet<PersonModel>? Person { get; set; }

        public PersonContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PersonContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
