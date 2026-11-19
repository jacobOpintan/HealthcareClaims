using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class ProviderConfiguration :IEntityTypeConfiguration<Provider>
{
    public void Configure (EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(p =>p.ProviderId);
        builder.Property(p=> p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.LicenseNumber).HasMaxLength(100).IsRequired();
        builder.Property(p=>p.Specialization).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(255).IsRequired();
        builder.Property(p=> p.PhoneNumber).HasMaxLength(30).IsRequired();
        builder.Property(p=> p.Address).HasMaxLength(500).IsRequired();
        builder.HasIndex(p=> p.Email);
        builder.HasIndex(p=> p.LicenseNumber).IsUnique();
    }
    
}
