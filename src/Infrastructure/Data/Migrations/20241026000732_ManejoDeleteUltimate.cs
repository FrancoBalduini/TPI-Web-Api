using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManejoDeleteUltimate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicletas_Usuarios_ClienteId",
                table: "Bicicletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Talleres_Usuarios_DuenoId",
                table: "Talleres");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicletas_Usuarios_ClienteId",
                table: "Bicicletas",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talleres_Usuarios_DuenoId",
                table: "Talleres",
                column: "DuenoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicletas_Usuarios_ClienteId",
                table: "Bicicletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Talleres_Usuarios_DuenoId",
                table: "Talleres");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicletas_Usuarios_ClienteId",
                table: "Bicicletas",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Talleres_Usuarios_DuenoId",
                table: "Talleres",
                column: "DuenoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
