using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.Domain.Entities;

namespace SC.Infrastructure.Mappings
{
    public class PlaylistMap : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable(nameof(Playlist), "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Playlist_id");

            builder.Property(x => x.CategoryId)
                .HasColumnName("Category_id");

            builder.OwnsOne(x => x.Name, x =>
            {
                x.Property(s => s.Value)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);
            });

            builder.OwnsOne(x => x.Price, x =>
            {
                x.Property(s => s.Value)
                    .HasColumnName("Price")
                    .HasColumnType("numeric(10,2)");
            });

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}