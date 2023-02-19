using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Accounts").HasKey("Id");
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x=>x.Username).IsRequired();
            builder.Property(x=>x.Password).IsRequired();
            builder.Property(x=>x.Mobile).IsRequired();
        }
    }
}
