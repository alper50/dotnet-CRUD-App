using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetApp.Migrations
{
    /// <inheritdoc />
    public partial class newModelsv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gruplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupIsim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciIsim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gruplar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
