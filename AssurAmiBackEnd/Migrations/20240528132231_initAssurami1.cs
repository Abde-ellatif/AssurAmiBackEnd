using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssurAmiBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class initAssurami1 : Migration
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
                    ErreurId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileStatuses_Erreurs_ErreurId",
                        column: x => x.ErreurId,
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
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFeet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    code1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GestionnaireId = table.Column<long>(type: "bigint", nullable: false),
                    AssureurId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Assureurs_AssureurId",
                        column: x => x.AssureurId,
                        principalTable: "Assureurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Gestionnaires_GestionnaireId",
                        column: x => x.GestionnaireId,
                        principalTable: "Gestionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AssureurId",
                table: "Clients",
                column: "AssureurId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GestionnaireId",
                table: "Clients",
                column: "GestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStatuses_ErreurId",
                table: "FileStatuses",
                column: "ErreurId");
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
