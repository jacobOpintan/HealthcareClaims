
using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class ClaimItemConfiguration
    : IEntityTypeConfiguration<ClaimItem>
{
    public void Configure(EntityTypeBuilder<ClaimItem> builder)
    {
        builder.HasKey(i => i.ClaimItemId);

        builder.Property(i => i.UnitPrice)
            .HasPrecision(18, 2);

        builder.Property(i => i.TotalPrice)
            .HasPrecision(18, 2);

        builder.HasOne<Claim>()
            .WithMany()
            .HasForeignKey(i => i.ClaimId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MedicalService>()
            .WithMany()
            .HasForeignKey(i => i.MedicalServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_ClaimItems_Quantity_Positive",
                "[Quantity] > 0");

            table.HasCheckConstraint(
                "CK_ClaimItems_UnitPrice_NonNegative",
                "[UnitPrice] >= 0");

            table.HasCheckConstraint(
                "CK_ClaimItems_TotalPrice_NonNegative",
                "[TotalPrice] >= 0");
        });
    }
}
