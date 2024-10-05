using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contrasenia = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NombreUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dueño",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Contrasenia = table.Column<string>(type: "TEXT", nullable: false),
                    NombreUser = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueño", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    DueñoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talleres_Dueño_DueñoId",
                        column: x => x.DueñoId,
                        principalTable: "Dueño",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TallerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_TallerId",
                table: "Mantenimiento",
                column: "TallerId");

            migrationBuilder.CreateIndex(
                name: "IX_Talleres_DueñoId",
                table: "Talleres",
                column: "DueñoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "Talleres");

            migrationBuilder.DropTable(
                name: "Dueño");
        }
    }
}
