using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class ClaimConfiguration :IEntityTypeConfiguration<Claim>
{
    public void Configure (EntityTypeBuilder<Claim> builder)
    {
        builder.HasKey(c => c.ClaimId);
        builder.Property(c =>c.ClaimNumber).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Status).HasMaxLength(30).IsRequired();
        builder.Property(c=>c.TotalAmount).HasPrecision(18,2);
        builder.Property(c => c.RejectionReason).HasMaxLength(1000);
        builder.HasIndex(c=>c.ClaimNumber).IsUnique();
        builder.HasOne<Patient>().WithMany().HasForeignKey(c=> c.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Provider>().WithMany().HasForeignKey(c =>c.ProviderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<InsurancePolicy>().WithMany().HasForeignKey(c=>c.InsurancePolicyId).OnDelete(DeleteBehavior.Restrict);
    }
    
}
