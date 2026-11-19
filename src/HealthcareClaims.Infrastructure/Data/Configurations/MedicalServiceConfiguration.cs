using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;
public class MedicalServiceConfiguration :IEntityTypeConfiguration<MedicalService>
{
    public void Configure (EntityTypeBuilder<MedicalService> builder)
    {
        builder.HasKey(s =>s.MedicalServiceId);
        builder.Property(s => s.ServiceCode).HasMaxLength(50).IsRequired();
        builder.Property(s => s.Name).HasMaxLength(200).IsRequired();
        builder.Property(s=> s.StandardPrice).HasPrecision(18,2);
        builder.Property(s => s.Description).HasMaxLength(1000).IsRequired();
        builder.Property(s=> s.IsActive).IsRequired();
        builder.HasIndex(s => s.ServiceCode).IsUnique();
    }
    
}
