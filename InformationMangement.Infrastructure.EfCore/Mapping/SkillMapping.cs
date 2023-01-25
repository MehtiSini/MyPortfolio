using InformationManagement.Domain.SkillsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationMangement.Infrastructure.EfCore.Mapping
{
    public class SkillMapping : IEntityTypeConfiguration<SkillModel>
    {
        public void Configure(EntityTypeBuilder<SkillModel> builder)
        {
            builder.ToTable("Skills").HasKey(x => x.Id);
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.Percent).IsRequired();

            builder.HasOne(x=>x.Person).WithMany(x=>x.Skills).HasForeignKey(x=>x.PersonId);
        }
    }
}
