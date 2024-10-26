using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManejoDeleteUltimate20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Talleres_TallerId",
                table: "Mantenimientos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }
    }
}
