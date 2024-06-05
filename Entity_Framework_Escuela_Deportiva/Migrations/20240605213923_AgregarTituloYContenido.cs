using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTituloYContenido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acudiente",
                columns: table => new
                {
                    IdAcudiente = table.Column<int>(type: "int", nullable: false),
                    Nombre_Acu = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellido_Acu = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telefono_Acu = table.Column<long>(type: "bigint", nullable: false),
                    Direccion_Acu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Acudient__7A8976E7FC4B7C58", x => x.IdAcudiente);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    Fecha_Fac = table.Column<DateOnly>(type: "date", nullable: false),
                    Valor_Fac = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Factura__50E7BAF1E27E14B2", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    Hora_Inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hora_Fin = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horario__1539229B98EE0B76", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    IdTorneo = table.Column<int>(type: "int", nullable: false),
                    Nombre_Tor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lugar_Tor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Tor = table.Column<DateOnly>(type: "date", nullable: false),
                    Direccion_Tor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Torneo__7757BBA039C0B7EC", x => x.IdTorneo);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grupo__303F6FD9C72E6860", x => x.IdGrupo);
                    table.ForeignKey(
                        name: "FK_Grupo_Horario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "IdHorario");
                });

            migrationBuilder.CreateTable(
                name: "Escuela",
                columns: table => new
                {
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Dirección = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<long>(type: "bigint", nullable: false),
                    IdTorneo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Escuela__D6C6BBF54788E93E", x => x.IdEscuela);
                    table.ForeignKey(
                        name: "FK_Escuela_Torneo",
                        column: x => x.IdTorneo,
                        principalTable: "Torneo",
                        principalColumn: "IdTorneo");
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<long>(type: "bigint", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Docente__64A8726ECAEFB411", x => x.IdDocente);
                    table.ForeignKey(
                        name: "FK_Docente_Grupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo");
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Doc = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Fecha_Nac = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AsisTotal = table.Column<int>(type: "int", nullable: true),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdAcudiente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TblPerso__C0308D6FC9FD091C", x => x.Doc);
                    table.ForeignKey(
                        name: "FK_Estudiante_Acudiente",
                        column: x => x.IdAcudiente,
                        principalTable: "Acudiente",
                        principalColumn: "IdAcudiente");
                    table.ForeignKey(
                        name: "FK_Estudiante_Factura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "IdFactura");
                    table.ForeignKey(
                        name: "FK_TblPersona_Grupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo");
                });

            migrationBuilder.CreateTable(
                name: "foro",
                columns: table => new
                {
                    IdForo = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false),
                    IdEscuela = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__foro__007D03DF2FD5AD2B", x => x.IdForo);
                    table.ForeignKey(
                        name: "FK_foro_Docente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "IdDocente");
                    table.ForeignKey(
                        name: "FK_foro_Escuela",
                        column: x => x.IdEscuela,
                        principalTable: "Escuela",
                        principalColumn: "IdEscuela");
                    table.ForeignKey(
                        name: "FK_foro_TblPersona",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "Doc");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docente_IdGrupo",
                table: "Docente",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Escuela_IdTorneo",
                table: "Escuela",
                column: "IdTorneo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdAcudiente",
                table: "Estudiante",
                column: "IdAcudiente");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdFactura",
                table: "Estudiante",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdGrupo",
                table: "Estudiante",
                column: "IdGrupo");

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
                name: "IX_Grupo_IdHorario",
                table: "Grupo",
                column: "IdHorario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foro");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Escuela");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Acudiente");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Horario");
        }
    }
}
