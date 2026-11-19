
using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthcareClaims.Infrastructure.Data.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.DocumentId);

        builder.Property(d => d.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(d => d.S3key)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(d => d.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.FileSize)
            .IsRequired();

        builder.HasIndex(d => d.S3key)
            .IsUnique();

        builder.HasOne<Claim>()
            .WithMany()
            .HasForeignKey(d => d.ClaimId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Documents_FileSize_Positive",
                "[FileSize] > 0");
        });
    }
}
