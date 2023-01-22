using InformationManagement.Domain.PersonAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationMangement.Infrastructure.EfCore.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.ToTable("Person").HasKey(x=>x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.ShortDescription).HasMaxLength(255);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PicturePath).HasMaxLength(1000);
            builder.Property(x => x.Address).HasMaxLength(300);
            builder.Property(x => x.Mobile).HasMaxLength(11);
        }
    }
}
