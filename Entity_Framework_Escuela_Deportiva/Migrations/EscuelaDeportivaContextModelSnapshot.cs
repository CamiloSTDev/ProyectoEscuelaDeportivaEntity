﻿// <auto-generated />
using System;
using Entity_Framework_Escuela_Deportiva.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity_Framework_Escuela_Deportiva.Migrations
{
    [DbContext(typeof(EscuelaDeportivaContext))]
    partial class EscuelaDeportivaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Acudiente", b =>
                {
                    b.Property<int>("IdAcudiente")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoAcu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Apellido_Acu");

                    b.Property<string>("DireccionAcu")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Direccion_Acu");

                    b.Property<string>("NombreAcu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre_Acu");

                    b.Property<long>("TelefonoAcu")
                        .HasColumnType("bigint")
                        .HasColumnName("Telefono_Acu");

                    b.HasKey("IdAcudiente")
                        .HasName("PK__Acudient__7A8976E7FC4B7C58");

                    b.ToTable("Acudiente", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Docente", b =>
                {
                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("contraseña");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint")
                        .HasColumnName("telefono");

                    b.HasKey("IdDocente")
                        .HasName("PK__Docente__64A8726ECAEFB411");

                    b.HasIndex("IdGrupo");

                    b.ToTable("Docente", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Escuela", b =>
                {
                    b.Property<int>("IdEscuela")
                        .HasColumnType("int");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Horario")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("IdTorneo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.HasKey("IdEscuela")
                        .HasName("PK__Escuela__D6C6BBF54788E93E");

                    b.HasIndex("IdTorneo");

                    b.ToTable("Escuela", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Estudiante", b =>
                {
                    b.Property<int>("Doc")
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("AsisTotal")
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FechaNac")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Fecha_Nac");

                    b.Property<int>("IdAcudiente")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)");

                    b.HasKey("Doc")
                        .HasName("PK__TblPerso__C0308D6FC9FD091C");

                    b.HasIndex("IdAcudiente");

                    b.HasIndex("IdGrupo");

                    b.ToTable("Estudiante", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("Doc")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaFac")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Fac");

                    b.Property<int>("ValorFac")
                        .HasColumnType("int")
                        .HasColumnName("Valor_Fac");

                    b.HasKey("IdFactura")
                        .HasName("PK__Factura__50E7BAF1E27E14B2");

                    b.HasIndex("Doc");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Foro", b =>
                {
                    b.Property<int>("IdForo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdForo"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<int?>("EscuelaIdEscuela")
                        .HasColumnType("int");

                    b.Property<int?>("EstudianteDoc")
                        .HasColumnType("int");

                    b.Property<int>("IdEscuela")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(123456);

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("IdForo")
                        .HasName("PK_IdForo");

                    b.HasIndex("EscuelaIdEscuela");

                    b.HasIndex("EstudianteDoc");

                    b.ToTable("foro", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Grupo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdGrupo")
                        .HasName("PK__Grupo__303F6FD9C72E6860");

                    b.HasIndex("IdHorario");

                    b.ToTable("Grupo", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time")
                        .HasColumnName("Hora_Fin");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time")
                        .HasColumnName("Hora_Inicio");

                    b.HasKey("IdHorario")
                        .HasName("PK__Horario__1539229B98EE0B76");

                    b.ToTable("Horario", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Torneo", b =>
                {
                    b.Property<int>("IdTorneo")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("DireccionTor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Direccion_Tor");

                    b.Property<DateOnly>("FechaTor")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Tor");

                    b.Property<string>("LugarTor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Lugar_Tor");

                    b.Property<string>("NombreTor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre_Tor");

                    b.HasKey("IdTorneo")
                        .HasName("PK__Torneo__7757BBA039C0B7EC");

                    b.ToTable("Torneo", (string)null);
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Docente", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Grupo", "IdGrupoNavigation")
                        .WithMany("Docentes")
                        .HasForeignKey("IdGrupo")
                        .IsRequired()
                        .HasConstraintName("FK_Docente_Grupo");

                    b.Navigation("IdGrupoNavigation");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Escuela", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Torneo", "IdTorneoNavigation")
                        .WithMany("Escuelas")
                        .HasForeignKey("IdTorneo")
                        .IsRequired()
                        .HasConstraintName("FK_Escuela_Torneo");

                    b.Navigation("IdTorneoNavigation");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Estudiante", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Acudiente", "IdAcudienteNavigation")
                        .WithMany("Estudiantes")
                        .HasForeignKey("IdAcudiente")
                        .IsRequired()
                        .HasConstraintName("FK_Estudiante_Acudiente");

                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Grupo", "IdGrupoNavigation")
                        .WithMany("Estudiantes")
                        .HasForeignKey("IdGrupo")
                        .IsRequired()
                        .HasConstraintName("FK_TblPersona_Grupo");

                    b.Navigation("IdAcudienteNavigation");

                    b.Navigation("IdGrupoNavigation");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Factura", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Estudiante", "DocNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("Doc")
                        .IsRequired();

                    b.Navigation("DocNavigation");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Foro", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Escuela", null)
                        .WithMany("Foros")
                        .HasForeignKey("EscuelaIdEscuela");

                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Estudiante", null)
                        .WithMany("Foros")
                        .HasForeignKey("EstudianteDoc");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Grupo", b =>
                {
                    b.HasOne("Entity_Framework_Escuela_Deportiva.Models.Horario", "IdHorarioNavigation")
                        .WithMany("Grupos")
                        .HasForeignKey("IdHorario")
                        .IsRequired()
                        .HasConstraintName("FK_Grupo_Horario");

                    b.Navigation("IdHorarioNavigation");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Acudiente", b =>
                {
                    b.Navigation("Estudiantes");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Escuela", b =>
                {
                    b.Navigation("Foros");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Estudiante", b =>
                {
                    b.Navigation("Facturas");

                    b.Navigation("Foros");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Grupo", b =>
                {
                    b.Navigation("Docentes");

                    b.Navigation("Estudiantes");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Horario", b =>
                {
                    b.Navigation("Grupos");
                });

            modelBuilder.Entity("Entity_Framework_Escuela_Deportiva.Models.Torneo", b =>
                {
                    b.Navigation("Escuelas");
                });
#pragma warning restore 612, 618
        }
    }
}
