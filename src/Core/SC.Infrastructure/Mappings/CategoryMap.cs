using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.Domain.Entities;

namespace SC.Infrastructure.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), "dbo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Category_id");

            builder.Property(u => u.Description)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}