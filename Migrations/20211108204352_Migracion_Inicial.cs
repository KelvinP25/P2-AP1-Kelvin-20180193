using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_KELVIN_20180193.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoTareas",
                columns: table => new
                {
                    TipoTareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionTipoTarea = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoAcumulado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTareas", x => x.TipoTareaId);
                });

            migrationBuilder.InsertData(
                table: "TipoTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 1, "Análisis", 0 });

            migrationBuilder.InsertData(
                table: "TipoTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 2, "Diseño", 0 });

            migrationBuilder.InsertData(
                table: "TipoTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 3, "Programación", 0 });

            migrationBuilder.InsertData(
                table: "TipoTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 4, "Prueba", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoTareas");
        }
    }
}
