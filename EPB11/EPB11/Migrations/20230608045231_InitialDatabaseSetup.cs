using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPB11.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achizitie",
                columns: table => new
                {
                    AchizitieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfflineOnline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unitate = table.Column<int>(type: "int", nullable: false),
                    PretPerUnitate = table.Column<int>(type: "int", nullable: false),
                    PretTotal = table.Column<int>(type: "int", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumaTotalaAchizitii = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achizitie", x => x.AchizitieId);
                });

            migrationBuilder.CreateTable(
                name: "Venit",
                columns: table => new
                {
                    VenitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sursa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suma = table.Column<int>(type: "int", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumaTotalaVenituri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venit", x => x.VenitId);
                });

            migrationBuilder.CreateTable(
                name: "Sold",
                columns: table => new
                {
                    SoldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenitId = table.Column<int>(type: "int", nullable: false),
                    AchizitieId = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sold", x => x.SoldId);
                    table.ForeignKey(
                        name: "FK_Sold_Achizitie_AchizitieId",
                        column: x => x.AchizitieId,
                        principalTable: "Achizitie",
                        principalColumn: "AchizitieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sold_Venit_VenitId",
                        column: x => x.VenitId,
                        principalTable: "Venit",
                        principalColumn: "VenitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obiectiv",
                columns: table => new
                {
                    ObiectivId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unitate = table.Column<int>(type: "int", nullable: false),
                    PretPerUnitate = table.Column<int>(type: "int", nullable: false),
                    SumaTotala = table.Column<int>(type: "int", nullable: false),
                    SoldId = table.Column<int>(type: "int", nullable: false),
                    SumaDeStrans = table.Column<int>(type: "int", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimpRamas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumaPerTimp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfflineOnline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obiectiv", x => x.ObiectivId);
                    table.ForeignKey(
                        name: "FK_Obiectiv_Sold_SoldId",
                        column: x => x.SoldId,
                        principalTable: "Sold",
                        principalColumn: "SoldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obiectiv_SoldId",
                table: "Obiectiv",
                column: "SoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_AchizitieId",
                table: "Sold",
                column: "AchizitieId");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_VenitId",
                table: "Sold",
                column: "VenitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obiectiv");

            migrationBuilder.DropTable(
                name: "Sold");

            migrationBuilder.DropTable(
                name: "Achizitie");

            migrationBuilder.DropTable(
                name: "Venit");
        }
    }
}
