
using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class InsurancePolicyConfiguration
    : IEntityTypeConfiguration<InsurancePolicy>
{
    public void Configure(EntityTypeBuilder<InsurancePolicy> builder)
    {
        builder.HasKey(p => p.InsurancePolicyId);

        builder.Property(p => p.PolicyNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.InsuranceProviderName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.CoverageLimit)
            .HasPrecision(18, 2);

        builder.Property(p => p.Status)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(p => p.PolicyNumber)
            .IsUnique();

        builder.HasOne<Patient>()
            .WithMany()
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
