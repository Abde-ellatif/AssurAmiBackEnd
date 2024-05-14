using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssurAmiBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitAssurAmiV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assureurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeAssureur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    libelet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assureurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Erreurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Erreurs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erreurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gestionnaires",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGestionnaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libellet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFichier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpload = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StockagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdErreur = table.Column<int>(type: "int", nullable: false),
                    erreurId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileStatuses_Erreurs_erreurId",
                        column: x => x.erreurId,
                        principalTable: "Erreurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateOnly>(type: "date", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFeet = table.Column<DateOnly>(type: "date", nullable: true),
                    DateSortie = table.Column<DateOnly>(type: "date", nullable: true),
                    IdGestionnaire = table.Column<int>(type: "int", nullable: false),
                    gestionnaireId = table.Column<long>(type: "bigint", nullable: true),
                    IdAssureur = table.Column<int>(type: "int", nullable: false),
                    assureurId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Assureurs_assureurId",
                        column: x => x.assureurId,
                        principalTable: "Assureurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Gestionnaires_gestionnaireId",
                        column: x => x.gestionnaireId,
                        principalTable: "Gestionnaires",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_assureurId",
                table: "Clients",
                column: "assureurId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_gestionnaireId",
                table: "Clients",
                column: "gestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStatuses_erreurId",
                table: "FileStatuses",
                column: "erreurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "FileStatuses");

            migrationBuilder.DropTable(
                name: "Assureurs");

            migrationBuilder.DropTable(
                name: "Gestionnaires");

            migrationBuilder.DropTable(
                name: "Erreurs");
        }
    }
}
