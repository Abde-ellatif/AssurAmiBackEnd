using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssurAmiBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AssurAmiV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActivateCompte",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivateCompte",
                table: "AspNetUsers");
        }
    }
}
