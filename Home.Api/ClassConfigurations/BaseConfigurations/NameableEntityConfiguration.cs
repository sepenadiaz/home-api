using Home.Api.Model.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Api.ClassConfigurations.BaseConfigurations
{
    public static class NameableEntityConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> entityTypeConfiguration) where T : NameableEntity
        {
            entityTypeConfiguration
                .Property(ent => ent.Name)
                .IsRequired()
                .HasColumnOrder(2);
        }
    }
}


