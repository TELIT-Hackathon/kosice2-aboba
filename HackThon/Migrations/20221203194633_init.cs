using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackThon.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseSquare = table.Column<int>(type: "int", nullable: false),
                    HouseRentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseRoomCount = table.Column<int>(type: "int", nullable: false),
                    HouseAnimalsAgree = table.Column<bool>(type: "bit", nullable: false),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HousePrice = table.Column<float>(type: "real", nullable: false),
                    HouseRentPrice = table.Column<float>(type: "real", nullable: false),
                    HouseImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseArea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
