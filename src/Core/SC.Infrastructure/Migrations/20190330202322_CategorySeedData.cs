using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.Infrastructure.Migrations
{
    public partial class CategorySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Category_id", "Description" },
                values: new object[,]
                {
                    { 1, "POP" },
                    { 2, "MPB" },
                    { 3, "CLASSIC" },
                    { 4, "ROCK" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Category_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Category",
                keyColumn: "Category_id",
                keyValue: 4);
        }
    }
}
