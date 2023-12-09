using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarMVC.Models;

public partial class ControlEscolarReactMvcContext : DbContext
{
    public ControlEscolarReactMvcContext()
    {
    }

    public ControlEscolarReactMvcContext(DbContextOptions<ControlEscolarReactMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoMateria> AlumnoMateria { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<ProgramaEstudio> ProgramaEstudios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; DataBase=ControlEscolarReactMVC; Integrated Security=true");
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.ToTable("Alumno");

            entity.Property(e => e.IdAlumno).ValueGeneratedNever();
            entity.Property(e => e.Correo).HasMaxLength(200);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Genero).HasMaxLength(20);
            entity.Property(e => e.Matricula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<AlumnoMateria>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoMateria);

            entity.Property(e => e.IdAlumnoMateria).ValueGeneratedNever();
            entity.Property(e => e.Calificacion).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Estatus).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Progreso).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoMateria)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK_AlumnoMateria_Alumno");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.AlumnoMateria)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK_AlumnoMateria_Materia");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria);

            entity.Property(e => e.IdMateria).ValueGeneratedNever();
            entity.Property(e => e.ClaveMateria).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK_Materia_Profesor");

            entity.HasOne(d => d.IdProgramaEstudioNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdProgramaEstudio)
                .HasConstraintName("FK_Materia_Programa");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor);

            entity.ToTable("Profesor");

            entity.Property(e => e.IdProfesor).ValueGeneratedNever();
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Genero).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Usuario).HasMaxLength(50);
        });

        modelBuilder.Entity<ProgramaEstudio>(entity =>
        {
            entity.HasKey(e => e.IdProgramaEstudio);

            entity.ToTable("ProgramaEstudio");

            entity.Property(e => e.IdProgramaEstudio).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
