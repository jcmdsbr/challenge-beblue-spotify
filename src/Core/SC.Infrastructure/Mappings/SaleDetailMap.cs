using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.Domain.Entities;

namespace SC.Infrastructure.Mappings
{
    public class SaleDetailMap : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable(nameof(SaleDetail), "dbo");

            builder.HasKey(x => new {x.SaleId, x.PlaylistId});

            builder.Property(x => x.SaleId)
                .HasColumnName("Sale_id")
                .IsRequired();

            builder.Property(x => x.PlaylistId)
                .HasColumnName("Playlist_id")
                .IsRequired();

            builder.OwnsOne(x => x.Cashback, x =>
            {
                x.Property(s => s.Value)
                    .HasColumnName("Cashback")
                    .HasColumnType("numeric(10,2)")
                    .IsRequired();
            });

            builder.HasOne(x => x.Playlist)
                .WithMany(x => x.SaleDetails)
                .HasForeignKey(e => e.PlaylistId)
                .IsRequired();

            builder.HasOne(x => x.Sale)
                .WithMany(x => x.Details)
                .HasForeignKey(e => e.SaleId)
                .IsRequired();
        }
    }
}