using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    /// <inheritdoc />
    public partial class AcutalizacionDeForo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.DropColumn(

                name: "IdDocente",

                table: "foro");


            migrationBuilder.AlterColumn<int>(

                name: "IdEscuela",

                table: "foro",

                nullable: false,

                defaultValue: 123456);

        }


        protected override void Down(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.AlterColumn<int>(

                name: "IdEscuela",

                table: "foro",

                nullable: false,

                oldClrType: typeof(int),

                oldDefaultValue: 123456);


            migrationBuilder.AddColumn<int>(

                name: "IdDocente",

                table: "foro",

                nullable: false,

                defaultValue: 0);

        }
    }
}
