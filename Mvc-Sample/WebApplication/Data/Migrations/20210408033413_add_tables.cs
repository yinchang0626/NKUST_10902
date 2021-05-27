using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Data.Migrations
{
    public partial class add_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrgId = table.Column<long>(type: "bigint", nullable: false),
                    PrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgAct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgStime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgEtime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgCont = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrgTicket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketSysUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationExits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevator = table.Column<bool>(type: "bit", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationExits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "StationExits");
        }
    }
}
