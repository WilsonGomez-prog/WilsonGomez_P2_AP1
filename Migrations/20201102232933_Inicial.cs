using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WilsonGomez_P2_AP1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposTarea",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTarea", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(nullable: false),
                    TipoTareaId = table.Column<int>(nullable: false),
                    Requerimiento = table.Column<string>(nullable: true),
                    Tiempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTarea",
                columns: new[] { "TipoId", "Descripcion" },
                values: new object[] { 1, "Análisis" });

            migrationBuilder.InsertData(
                table: "TiposTarea",
                columns: new[] { "TipoId", "Descripcion" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "TiposTarea",
                columns: new[] { "TipoId", "Descripcion" },
                values: new object[] { 3, "Programación" });

            migrationBuilder.InsertData(
                table: "TiposTarea",
                columns: new[] { "TipoId", "Descripcion" },
                values: new object[] { 4, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "TiposTarea");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
