using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetApp.Migrations
{
    /// <inheritdoc />
    public partial class newModelsv9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YetkiIsmi",
                table: "Yetkiler");

            migrationBuilder.AddColumn<string>(
                name: "YetkiIsim",
                table: "Yetkiler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciIsim",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YetkiIsim",
                table: "Yetkiler");

            migrationBuilder.AddColumn<string>(
                name: "YetkiIsmi",
                table: "Yetkiler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciIsim",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
