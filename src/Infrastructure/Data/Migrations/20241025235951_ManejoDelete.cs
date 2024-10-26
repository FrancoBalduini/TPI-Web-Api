using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManejoDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id");
        }
    }
}
