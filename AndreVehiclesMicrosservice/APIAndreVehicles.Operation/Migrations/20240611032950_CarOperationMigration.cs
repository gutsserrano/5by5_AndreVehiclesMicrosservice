using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAndreVehicles.Operation.Migrations
{
    public partial class CarOperationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Plate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Plate);
                });

            migrationBuilder.CreateTable(
                name: "CarOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOperations_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_CarOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_CarPlate",
                table: "CarOperations",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_OperationId",
                table: "CarOperations",
                column: "OperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOperations");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
