using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.Domain.Models;

namespace SC.Infrastructure.Mappings
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable (nameof (Sale), "dbo");

            builder.HasKey (x => x.Id);

            builder.Property (x => x.Id)
                .HasColumnName ("Sale_id");

            builder.Property (x => x.RealizedAt)
                .HasColumnName ("RealizedAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder.OwnsOne (x => x.Cashback, x => {
                x.Property (s => s.Value)
                    .HasColumnName ("Cashback")
                    .HasColumnType("numeric(10,2)")
                    .IsRequired();
            });

            builder.OwnsOne (x => x.CustomerCpf, x => {
                x.Property (s => s.Value)
                    .HasColumnName ("Customer_cpf")
                    .HasColumnType("numeric(14)")
                    .IsRequired();
            });

            builder.OwnsOne (x => x.Price, x => {
                x.Property (s => s.Value)
                    .HasColumnName ("Price")
                    .HasColumnType ("numeric(10,2)")
                    .IsRequired();
            });
            
        }
    }
}
