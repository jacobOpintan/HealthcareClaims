using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.PatientId);
        builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Gender).HasMaxLength(30).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(500).IsRequired();
        builder.HasIndex(p => p.Email).IsUnique();
        builder.HasIndex(p => p.UserId).IsUnique().HasFilter("[UserId] IS NOT NULL");
    }

}
