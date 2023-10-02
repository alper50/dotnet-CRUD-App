using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetApp.Migrations
{
    /// <inheritdoc />
    public partial class newModelsv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "YetkiGrup",
                newName: "GrupId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Kullanicilar",
                newName: "GrupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrupId",
                table: "YetkiGrup",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "GrupId",
                table: "Kullanicilar",
                newName: "GroupId");
        }
    }
}
