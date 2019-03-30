using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "dbo");

            migrationBuilder.CreateTable(
                "Category",
                schema: "dbo",
                columns: table => new
                {
                    Category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>("varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Category", x => x.Category_id); });

            migrationBuilder.CreateTable(
                "Sale",
                schema: "dbo",
                columns: table => new
                {
                    Sale_id = table.Column<Guid>(nullable: false),
                    RealizedAt = table.Column<DateTime>("datetime", nullable: false),
                    Price = table.Column<decimal>("numeric(10,2)", nullable: false),
                    Cashback = table.Column<decimal>("numeric(10,2)", nullable: false),
                    Customer_cpf = table.Column<decimal>("numeric(14)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Sale", x => x.Sale_id); });

            migrationBuilder.CreateTable(
                "Playlist",
                schema: "dbo",
                columns: table => new
                {
                    Playlist_id = table.Column<Guid>(nullable: false),
                    Category_id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>("numeric(10,2)", nullable: false),
                    Name = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Playlist_id);
                    table.ForeignKey(
                        "FK_Playlist_Category_Category_id",
                        x => x.Category_id,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SaleDetail",
                schema: "dbo",
                columns: table => new
                {
                    Sale_id = table.Column<Guid>(nullable: false),
                    Playlist_id = table.Column<Guid>(nullable: false),
                    Cashback = table.Column<decimal>("numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => new {x.Sale_id, x.Playlist_id});
                    table.ForeignKey(
                        "FK_SaleDetail_Playlist_Playlist_id",
                        x => x.Playlist_id,
                        principalSchema: "dbo",
                        principalTable: "Playlist",
                        principalColumn: "Playlist_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_SaleDetail_Sale_Sale_id",
                        x => x.Sale_id,
                        principalSchema: "dbo",
                        principalTable: "Sale",
                        principalColumn: "Sale_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Playlist_Category_id",
                schema: "dbo",
                table: "Playlist",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                "IX_SaleDetail_Playlist_id",
                schema: "dbo",
                table: "SaleDetail",
                column: "Playlist_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "SaleDetail",
                "dbo");

            migrationBuilder.DropTable(
                "Playlist",
                "dbo");

            migrationBuilder.DropTable(
                "Sale",
                "dbo");

            migrationBuilder.DropTable(
                "Category",
                "dbo");
        }
    }
}