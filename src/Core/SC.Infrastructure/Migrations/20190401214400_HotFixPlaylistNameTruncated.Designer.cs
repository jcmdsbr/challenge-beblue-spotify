﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SC.Infrastructure;

namespace SC.Infrastructure.Migrations
{
    [DbContext(typeof(SCContext))]
    [Migration("20190401214400_HotFixPlaylistNameTruncated")]
    partial class HotFixPlaylistNameTruncated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SC.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Category_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Category","dbo");

                    b.HasData(
                        new { Id = 1, Description = "POP" },
                        new { Id = 2, Description = "MPB" },
                        new { Id = 3, Description = "CLASSIC" },
                        new { Id = 4, Description = "ROCK" }
                    );
                });

            modelBuilder.Entity("SC.Domain.Entities.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Playlist_id");

                    b.Property<int>("CategoryId")
                        .HasColumnName("Category_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Playlist","dbo");
                });

            modelBuilder.Entity("SC.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Sale_id");

                    b.Property<DateTime>("RealizedAt")
                        .HasColumnName("RealizedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Sale","dbo");
                });

            modelBuilder.Entity("SC.Domain.Entities.SaleDetail", b =>
                {
                    b.Property<Guid>("SaleId")
                        .HasColumnName("Sale_id");

                    b.Property<Guid>("PlaylistId")
                        .HasColumnName("Playlist_id");

                    b.HasKey("SaleId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("SaleDetail","dbo");
                });

            modelBuilder.Entity("SC.Domain.Entities.Playlist", b =>
                {
                    b.HasOne("SC.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SC.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("PlaylistId");

                            b1.Property<string>("Value")
                                .HasColumnName("Name")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(50);

                            b1.ToTable("Playlist","dbo");

                            b1.HasOne("SC.Domain.Entities.Playlist")
                                .WithOne("Name")
                                .HasForeignKey("SC.Domain.ValueObjects.Name", "PlaylistId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SC.Domain.ValueObjects.Amount", "Price", b1 =>
                        {
                            b1.Property<Guid>("PlaylistId");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Price")
                                .HasColumnType("numeric(10,2)");

                            b1.ToTable("Playlist","dbo");

                            b1.HasOne("SC.Domain.Entities.Playlist")
                                .WithOne("Price")
                                .HasForeignKey("SC.Domain.ValueObjects.Amount", "PlaylistId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SC.Domain.Entities.Sale", b =>
                {
                    b.OwnsOne("SC.Domain.ValueObjects.Cpf", "CustomerCpf", b1 =>
                        {
                            b1.Property<Guid?>("SaleId");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Customer_cpf")
                                .HasColumnType("numeric(14)");

                            b1.ToTable("Sale","dbo");

                            b1.HasOne("SC.Domain.Entities.Sale")
                                .WithOne("CustomerCpf")
                                .HasForeignKey("SC.Domain.ValueObjects.Cpf", "SaleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SC.Domain.ValueObjects.Amount", "Cashback", b1 =>
                        {
                            b1.Property<Guid>("SaleId");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Cashback")
                                .HasColumnType("numeric(10,2)");

                            b1.ToTable("Sale","dbo");

                            b1.HasOne("SC.Domain.Entities.Sale")
                                .WithOne("Cashback")
                                .HasForeignKey("SC.Domain.ValueObjects.Amount", "SaleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SC.Domain.ValueObjects.Amount", "Price", b1 =>
                        {
                            b1.Property<Guid?>("SaleId");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Price")
                                .HasColumnType("numeric(10,2)");

                            b1.ToTable("Sale","dbo");

                            b1.HasOne("SC.Domain.Entities.Sale")
                                .WithOne("Price")
                                .HasForeignKey("SC.Domain.ValueObjects.Amount", "SaleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SC.Domain.Entities.SaleDetail", b =>
                {
                    b.HasOne("SC.Domain.Entities.Playlist", "Playlist")
                        .WithMany("SaleDetails")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SC.Domain.Entities.Sale", "Sale")
                        .WithMany("Details")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SC.Domain.ValueObjects.Amount", "Cashback", b1 =>
                        {
                            b1.Property<Guid>("SaleDetailSaleId");

                            b1.Property<Guid>("SaleDetailPlaylistId");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Cashback")
                                .HasColumnType("numeric(10,2)");

                            b1.ToTable("SaleDetail","dbo");

                            b1.HasOne("SC.Domain.Entities.SaleDetail")
                                .WithOne("Cashback")
                                .HasForeignKey("SC.Domain.ValueObjects.Amount", "SaleDetailSaleId", "SaleDetailPlaylistId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
