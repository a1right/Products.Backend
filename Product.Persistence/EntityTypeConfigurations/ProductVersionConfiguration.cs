using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;

namespace Products.Persistence.EntityTypeConfigurations
{
    public class ProductVersionConfiguration : IEntityTypeConfiguration<ProductVersion>
    {
        public void Configure(EntityTypeBuilder<ProductVersion> builder)
        {
            builder.ToTable("ProductVersion");

            builder.HasIndex(e => e.CreatingDate, "IX_ProductVersion_CreatingDate");

            builder.HasIndex(e => e.Height, "IX_ProductVersion_VersionHeight");

            builder.HasIndex(e => e.Length, "IX_ProductVersion_VersionLength");

            builder.HasIndex(e => e.Name, "IX_ProductVersion_VersionName");

            builder.HasIndex(e => e.Width, "IX_ProductVersion_VersionWidth");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.CreatingDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Height).HasColumnType("decimal(7, 2)");

            builder.Property(e => e.Length).HasColumnType("decimal(7, 2)");

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.ProductId).HasColumnName("ProductID");

            builder.Property(e => e.Width).HasColumnType("decimal(7, 2)");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductVersions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductVe__Produ__286302EC");
        }
    }
}
