using Home.Api.ClassConfigurations.BaseConfigurations;
using Home.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Api
{
    public partial class Context { public DbSet<Purchase> Purchases { get; set; } = null!; }
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            IdentifiableEntityConfiguration.Configure(builder);
            builder.Property(ent => ent.Description).HasMaxLength(50);
            builder.Property(ent => ent.Amount).HasPrecision(18, 2);
        }
    }
}


