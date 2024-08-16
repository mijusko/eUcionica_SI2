using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eUcionica.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPredmeta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oblast",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblast", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oblast_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredmetID = table.Column<int>(type: "int", nullable: false),
                    OblastID = table.Column<int>(type: "int", nullable: false),
                    NivoTezine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PitanjeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacanOdgovor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pitanje_Oblast_OblastID",
                        column: x => x.OblastID,
                        principalTable: "Oblast",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pitanje_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oblast_PredmetID",
                table: "Oblast",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_OblastID",
                table: "Pitanje",
                column: "OblastID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_PredmetID",
                table: "Pitanje",
                column: "PredmetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "Oblast");

            migrationBuilder.DropTable(
                name: "Predmet");
        }
    }
}
