using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrosEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class SincronizarCambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EdadEstudiantes",
                table: "Estudiantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EdadEstudiantes",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
