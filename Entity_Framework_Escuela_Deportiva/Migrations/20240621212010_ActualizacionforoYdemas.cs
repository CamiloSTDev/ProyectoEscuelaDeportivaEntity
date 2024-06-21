using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    public partial class ActualizacionforoYdemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_Docente",
                table: "foro");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_Escuela",
                table: "foro");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_TblPersona",
                table: "foro");

            migrationBuilder.DropPrimaryKey(
                name: "PK__foro__007D03DF2FD5AD2B",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_IdDocente",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_IdEscuela",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_IdEstudiante",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_IdFactura",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "IdDocente",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "IdPublicacion",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                table: "Estudiante");

            // Eliminamos la columna IdForo existente
            migrationBuilder.DropColumn(
                name: "IdForo",
                table: "foro");

            // Agregamos de nuevo la columna IdForo con la propiedad IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "IdForo",
                table: "foro",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EscuelaIdEscuela",
                table: "foro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstudianteDoc",
                table: "foro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doc",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdForo",
                table: "foro",
                column: "IdForo");

            migrationBuilder.CreateIndex(
                name: "IX_foro_EscuelaIdEscuela",
                table: "foro",
                column: "EscuelaIdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_foro_EstudianteDoc",
                table: "foro",
                column: "EstudianteDoc");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_Doc",
                table: "Factura",
                column: "Doc");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Estudiante_Doc",
                table: "Factura",
                column: "Doc",
                principalTable: "Estudiante",
                principalColumn: "Doc");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_Escuela_EscuelaIdEscuela",
                table: "foro",
                column: "EscuelaIdEscuela",
                principalTable: "Escuela",
                principalColumn: "IdEscuela");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_Estudiante_EstudianteDoc",
                table: "foro",
                column: "EstudianteDoc",
                principalTable: "Estudiante",
                principalColumn: "Doc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Estudiante_Doc",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_Escuela_EscuelaIdEscuela",
                table: "foro");

            migrationBuilder.DropForeignKey(
                name: "FK_foro_Estudiante_EstudianteDoc",
                table: "foro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdForo",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_EscuelaIdEscuela",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_foro_EstudianteDoc",
                table: "foro");

            migrationBuilder.DropIndex(
                name: "IX_Factura_Doc",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "EscuelaIdEscuela",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "EstudianteDoc",
                table: "foro");

            migrationBuilder.DropColumn(
                name: "Doc",
                table: "Factura");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "foro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "IdEscuela",
                table: "foro",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 123456);

            migrationBuilder.AlterColumn<string>(
                name: "Contenido",
                table: "foro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "");

            // Revertimos los cambios a la columna IdForo
            migrationBuilder.AlterColumn<int>(
                name: "IdForo",
                table: "foro",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__foro__007D03DF2FD5AD2B",
                table: "foro",
                column: "IdForo");

            migrationBuilder.CreateIndex(
                name: "IX_foro_IdDocente",
                table: "foro",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_foro_IdEscuela",
                table: "foro",
                column: "IdEscuela");

            migrationBuilder.CreateIndex(
                name: "IX_foro_IdEstudiante",
                table: "foro",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdFactura",
                table: "Estudiante",
                column: "IdFactura");

            migrationBuilder.AddColumn<int>(
                name: "IdDocente",
                table: "foro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPublicacion",
                table: "foro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                table: "Estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Factura",
                table: "Estudiante",
                column: "IdFactura",
                principalTable: "Factura",
                principalColumn: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_Docente",
                table: "foro",
                column: "IdDocente",
                principalTable: "Docente",
                principalColumn: "IdDocente");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_Escuela",
                table: "foro",
                column: "IdEscuela",
                principalTable: "Escuela",
                principalColumn: "IdEscuela");

            migrationBuilder.AddForeignKey(
                name: "FK_foro_TblPersona",
                table: "foro",
                column: "IdEstudiante",
                principalTable: "Estudiante",
                principalColumn: "Doc");
        }
    }
}
