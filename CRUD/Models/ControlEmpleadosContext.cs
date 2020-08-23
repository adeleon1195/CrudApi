using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD.Models
{
    public partial class ControlEmpleadosContext : DbContext
    {
        public ControlEmpleadosContext()
        {
        }

        public ControlEmpleadosContext(DbContextOptions<ControlEmpleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbDepartamentos> TbDepartamentos { get; set; }
        public virtual DbSet<TbEmpleados> TbEmpleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ST5FLPP6;Database=ControlEmpleados;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbDepartamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepto);

                entity.ToTable("tb-Departamentos");

                entity.Property(e => e.CodigoDepto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripDepto).IsUnicode(false);

                entity.Property(e => e.NombreDepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbEmpleados>(entity =>
            {
                entity.HasKey(e => e.IdEmp);

                entity.ToTable("tb-Empleados");

                entity.Property(e => e.ApellidoEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEmp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacEmp).HasColumnType("date");

                entity.Property(e => e.NombreEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDeptoNavigation)
                    .WithMany(p => p.TbEmpleados)
                    .HasForeignKey(d => d.IdDepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb-Empleados_tb-Departamentos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
