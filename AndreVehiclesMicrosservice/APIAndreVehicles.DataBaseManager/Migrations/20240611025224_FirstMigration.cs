using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAndreVehicles.DataBaseManager.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicPlaceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankSlips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankSlips", x => x.Id);
                });

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
                name: "Card",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameInCard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PixTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PixTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Document);
                    table.ForeignKey(
                        name: "FK_People_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buys_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "Plate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CarPlate1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OperationId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_CarOperations_Car_CarPlate1",
                        column: x => x.CarPlate1,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_CarOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOperations_Operations_OperationId1",
                        column: x => x.OperationId1,
                        principalTable: "Operations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PixTypeId = table.Column<int>(type: "int", nullable: false),
                    PixKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PixTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pixes_PixTypes_PixTypeId",
                        column: x => x.PixTypeId,
                        principalTable: "PixTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pixes_PixTypes_PixTypeId1",
                        column: x => x.PixTypeId1,
                        principalTable: "PixTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentPdf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Document);
                    table.ForeignKey(
                        name: "FK_Client_People_Document",
                        column: x => x.Document,
                        principalTable: "People",
                        principalColumn: "Document");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    ComissionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Document);
                    table.ForeignKey(
                        name: "FK_Employee_People_Document",
                        column: x => x.Document,
                        principalTable: "People",
                        principalColumn: "Document");
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BankSlipId = table.Column<int>(type: "int", nullable: true),
                    PixId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_BankSlips_BankSlipId",
                        column: x => x.BankSlipId,
                        principalTable: "BankSlips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Card_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "Card",
                        principalColumn: "CardNumber");
                    table.ForeignKey(
                        name: "FK_Payments_Pixes_PixId",
                        column: x => x.PixId,
                        principalTable: "Pixes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SellDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sells_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "Plate");
                    table.ForeignKey(
                        name: "FK_Sells_Client_ClientDocument",
                        column: x => x.ClientDocument,
                        principalTable: "Client",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Employee_EmployeeDocument",
                        column: x => x.EmployeeDocument,
                        principalTable: "Employee",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_CarPlate",
                table: "Buys",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_CarPlate",
                table: "CarOperations",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_CarPlate1",
                table: "CarOperations",
                column: "CarPlate1");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_OperationId",
                table: "CarOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOperations_OperationId1",
                table: "CarOperations",
                column: "OperationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BankSlipId",
                table: "Payments",
                column: "BankSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CardNumber",
                table: "Payments",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PixId",
                table: "Payments",
                column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Pixes_PixTypeId",
                table: "Pixes",
                column: "PixTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pixes_PixTypeId1",
                table: "Pixes",
                column: "PixTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_CarPlate",
                table: "Sells",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_ClientDocument",
                table: "Sells",
                column: "ClientDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_EmployeeDocument",
                table: "Sells",
                column: "EmployeeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_PaymentId",
                table: "Sells",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buys");

            migrationBuilder.DropTable(
                name: "CarOperations");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "BankSlips");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Pixes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PixTypes");
        }
    }
}
