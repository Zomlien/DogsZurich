using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogsZurich.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ageclass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ageclass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breedstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breedstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breedtype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breedtype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kreis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kreis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quartier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogowner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    QuartierId = table.Column<int>(type: "int", nullable: false),
                    KreisId = table.Column<int>(type: "int", nullable: false),
                    AgeclassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogowner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogowner_Ageclass_AgeclassId",
                        column: x => x.AgeclassId,
                        principalTable: "Ageclass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogowner_Kreis_KreisId",
                        column: x => x.KreisId,
                        principalTable: "Kreis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogowner_Quartier_QuartierId",
                        column: x => x.QuartierId,
                        principalTable: "Quartier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogowner_Sex_SexId",
                        column: x => x.SexId,
                        principalTable: "Sex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    Breed1Id = table.Column<int>(type: "int", nullable: false),
                    Breed2Id = table.Column<int>(type: "int", nullable: true),
                    BreedstatusId = table.Column<int>(type: "int", nullable: false),
                    BreedtypeId = table.Column<int>(type: "int", nullable: false),
                    DogownerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Breed_Breed1Id",
                        column: x => x.Breed1Id,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Breed_Breed2Id",
                        column: x => x.Breed2Id,
                        principalTable: "Breed",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dogs_Breedstatus_BreedstatusId",
                        column: x => x.BreedstatusId,
                        principalTable: "Breedstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Breedtype_BreedtypeId",
                        column: x => x.BreedtypeId,
                        principalTable: "Breedtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Color_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Dogowner_DogownerId",
                        column: x => x.DogownerId,
                        principalTable: "Dogowner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Sex_SexId",
                        column: x => x.SexId,
                        principalTable: "Sex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogowner_AgeclassId",
                table: "Dogowner",
                column: "AgeclassId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogowner_KreisId",
                table: "Dogowner",
                column: "KreisId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogowner_QuartierId",
                table: "Dogowner",
                column: "QuartierId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogowner_SexId",
                table: "Dogowner",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_Breed1Id",
                table: "Dogs",
                column: "Breed1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_Breed2Id",
                table: "Dogs",
                column: "Breed2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedstatusId",
                table: "Dogs",
                column: "BreedstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedtypeId",
                table: "Dogs",
                column: "BreedtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ColorsId",
                table: "Dogs",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogownerId",
                table: "Dogs",
                column: "DogownerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_SexId",
                table: "Dogs",
                column: "SexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Breedstatus");

            migrationBuilder.DropTable(
                name: "Breedtype");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Dogowner");

            migrationBuilder.DropTable(
                name: "Ageclass");

            migrationBuilder.DropTable(
                name: "Kreis");

            migrationBuilder.DropTable(
                name: "Quartier");

            migrationBuilder.DropTable(
                name: "Sex");
        }
    }
}
