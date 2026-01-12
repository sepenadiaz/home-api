using Home.Api.Model.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Api.ClassConfigurations.BaseConfigurations
{
    public static class IdentifiableEntityConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> entityTypeConfiguration) where T : IdentifiableEntity
        {
            entityTypeConfiguration.HasKey(ent => ent.Id);
            entityTypeConfiguration.Property(ent => ent.Id).HasColumnOrder(1);
        }
    }
}


