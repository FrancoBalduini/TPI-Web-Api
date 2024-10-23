using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablaDbSetMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Bicicletas_BicicletaId",
                table: "Mantenimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_Talleres_TallerId",
                table: "Mantenimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mantenimiento",
                table: "Mantenimiento");

            migrationBuilder.RenameTable(
                name: "Mantenimiento",
                newName: "Mantenimientos");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimiento_TallerId",
                table: "Mantenimientos",
                newName: "IX_Mantenimientos_TallerId");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimiento_BicicletaId",
                table: "Mantenimientos",
                newName: "IX_Mantenimientos_BicicletaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mantenimientos",
                table: "Mantenimientos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Bicicletas_BicicletaId",
                table: "Mantenimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mantenimientos",
                table: "Mantenimientos");

            migrationBuilder.RenameTable(
                name: "Mantenimientos",
                newName: "Mantenimiento");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimientos_TallerId",
                table: "Mantenimiento",
                newName: "IX_Mantenimiento_TallerId");

            migrationBuilder.RenameIndex(
                name: "IX_Mantenimientos_BicicletaId",
                table: "Mantenimiento",
                newName: "IX_Mantenimiento_BicicletaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mantenimiento",
                table: "Mantenimiento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_Bicicletas_BicicletaId",
                table: "Mantenimiento",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_Talleres_TallerId",
                table: "Mantenimiento",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }
    }
}
