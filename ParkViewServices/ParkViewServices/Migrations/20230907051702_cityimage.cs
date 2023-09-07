using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkViewServices.Migrations
{
    public partial class cityimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityImage_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityImage",
                columns: new[] { "Id", "CityId", "ImagePath" },
                values: new object[,]
                {
                    { 1, 1, "~/images/new_delhi.jpg" },
                    { 2, 2, "~/images/mumbai.jpg" },
                    { 3, 3, "~/images/male.jpg" },
                    { 4, 4, "~/images/bangkok.jpg" },
                    { 5, 5, "~/images/beijing.jpg" },
                    { 6, 6, "~/images/chennai.jpg" },
                    { 7, 7, "~/images/kolkata.jpg" },
                    { 8, 8, "~/images/colombo.jpg" },
                    { 9, 9, "~/images/phuket.jpg" },
                    { 10, 10, "~/images/shanghai.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityImage_CityId",
                table: "CityImage",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityImage");
        }
    }
}
