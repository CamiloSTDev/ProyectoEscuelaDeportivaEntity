using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Escuela_Deportiva.Models;

public partial class EscuelaDeportivaContext : DbContext
{
    public EscuelaDeportivaContext()
    {
    }

    public EscuelaDeportivaContext(DbContextOptions<EscuelaDeportivaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acudiente> Acudientes { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Escuela> Escuelas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Foro> Foros { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0N9C8DO\\SQLEXPRESS;Database=Escuela_Deportiva;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acudiente>(entity =>
        {
            entity.HasKey(e => e.IdAcudiente).HasName("PK__Acudient__7A8976E7FC4B7C58");

            entity.ToTable("Acudiente");

            entity.Property(e => e.IdAcudiente).ValueGeneratedNever();
            entity.Property(e => e.ApellidoAcu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Apellido_Acu");
            entity.Property(e => e.DireccionAcu)
                .HasMaxLength(200)
                .HasColumnName("Direccion_Acu");
            entity.Property(e => e.NombreAcu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Acu");
            entity.Property(e => e.TelefonoAcu).HasColumnName("Telefono_Acu");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docente__64A8726ECAEFB411");

            entity.ToTable("Docente");

            entity.Property(e => e.IdDocente).ValueGeneratedNever();
            entity.Property(e => e.Contraseña)
                .HasMaxLength(16)
                .HasColumnName("contraseña");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Docente_Grupo");
        });

        modelBuilder.Entity<Escuela>(entity =>
        {
            entity.HasKey(e => e.IdEscuela).HasName("PK__Escuela__D6C6BBF54788E93E");

            entity.ToTable("Escuela");

            entity.Property(e => e.IdEscuela).ValueGeneratedNever();
            entity.Property(e => e.Dirección).HasMaxLength(30);
            entity.Property(e => e.Horario).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(40);

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Escuelas)
                .HasForeignKey(d => d.IdTorneo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Escuela_Torneo");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Doc).HasName("PK__TblPerso__C0308D6FC9FD091C");

            entity.ToTable("Estudiante");

            entity.Property(e => e.Doc).ValueGeneratedNever();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaNac)
                .HasMaxLength(10)
                .HasColumnName("Fecha_Nac");
            entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAcudienteNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdAcudiente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estudiante_Acudiente");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblPersona_Grupo");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__50E7BAF1E27E14B2");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).ValueGeneratedNever();
            entity.Property(e => e.FechaFac).HasColumnName("Fecha_Fac");
            entity.Property(e => e.ValorFac).HasColumnName("Valor_Fac");

            entity.HasOne(d => d.DocNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Doc)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Foro>(entity =>
        {
            entity.HasKey(e => e.IdForo).HasName("PK_IdForo");

            entity.ToTable("foro");

            entity.Property(e => e.Contenido).HasDefaultValue("");
            entity.Property(e => e.Titulo).HasDefaultValue("");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupo__303F6FD9C72E6860");

            entity.ToTable("Grupo");

            entity.Property(e => e.IdGrupo).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_Horario");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horario__1539229B98EE0B76");

            entity.ToTable("Horario");

            entity.Property(e => e.IdHorario).ValueGeneratedNever();
            entity.Property(e => e.HoraFin).HasColumnName("Hora_Fin");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_Inicio");
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.IdTorneo).HasName("PK__Torneo__7757BBA039C0B7EC");

            entity.ToTable("Torneo");

            entity.Property(e => e.IdTorneo).ValueGeneratedNever();
            entity.Property(e => e.Ciudad).HasMaxLength(45);
            entity.Property(e => e.DireccionTor)
                .HasMaxLength(100)
                .HasColumnName("Direccion_Tor");
            entity.Property(e => e.FechaTor).HasColumnName("Fecha_Tor");
            entity.Property(e => e.LugarTor)
                .HasMaxLength(50)
                .HasColumnName("Lugar_Tor");
            entity.Property(e => e.NombreTor)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Tor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
