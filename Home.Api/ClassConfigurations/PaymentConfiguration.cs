using Home.Api.ClassConfigurations.BaseConfigurations;
using Home.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Api
{
    public partial class Context { public DbSet<Payment> Payments { get; set; } }
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            IdentifiableEntityConfiguration.Configure(builder);
            builder.Property(ent => ent.Amount).HasPrecision(18, 2);
        }
    }
}



