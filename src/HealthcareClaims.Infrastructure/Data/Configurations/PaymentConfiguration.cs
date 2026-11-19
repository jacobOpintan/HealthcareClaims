using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class PaymentConfiguration: IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
       builder.HasKey(p =>p.PaymentId);
       builder.Property(p=> p.PaymentReference).HasMaxLength(100).IsRequired();
       builder.Property(p=>p.Amount).HasPrecision(18,2);
       builder.Property(p => p.PaymentMethod).HasMaxLength(50).IsRequired();
       builder.Property(p =>p.Status).HasMaxLength(30).IsRequired();
       builder.HasIndex(p=>p.PaymentReference).IsUnique();
       builder.HasIndex(p => p.ClaimId).IsUnique();

       builder.HasOne<Claim>().WithOne().HasForeignKey<Payment>(p =>p.ClaimId).OnDelete(DeleteBehavior.Restrict);
       builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Payments_Amount_NonNegative",
                "[Amount] >= 0");
        });
    }
    
}
