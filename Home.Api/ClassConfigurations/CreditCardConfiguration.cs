using Home.Api.ClassConfigurations.BaseConfigurations;
using Home.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Api
{
    public partial class Context { public DbSet<CreditCard> CreditCards { get; set; } = null!; }
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            IdentifiableEntityConfiguration.Configure(builder);
            builder.ToTable("credit_cards");

            builder.Property(ent => ent.Bank).HasMaxLength(50);
            builder.Property(ent => ent.CardBrand).HasMaxLength(50);
            builder.Property(ent => ent.LogoPath).HasMaxLength(500);
            builder.Property(ent => ent.Color).HasMaxLength(50);
        }
    }
}


