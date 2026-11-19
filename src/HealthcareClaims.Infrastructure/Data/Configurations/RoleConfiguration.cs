
using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(r => r.Description)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasIndex(r => r.Name)
            .IsUnique();
    }
}
