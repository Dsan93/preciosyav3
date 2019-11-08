using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NetTopologySuite.Geometries;


namespace preciosyav3.Models
{
    public partial class proyectosoftContext : DbContext
    {
        public proyectosoftContext()
        {
        }

        public proyectosoftContext(DbContextOptions<proyectosoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comercio> Comercio { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Data Source=DSAN\\SANSQL;Initial Catalog=proyectosoft;Integrated Security=True;MultipleActiveResultSets=True", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Comercio>(options =>
            //{
            //    options.Property(m => m.ComUbicacion).HasColumnType("geography");
            //});

            modelBuilder.Entity<Comercio>(entity =>
            { 
                entity.HasKey(e => e.ComId);

                entity.Property(e => e.ComId).HasColumnName("comId");

                entity.Property(e => e.ComDescripcion)
                    .IsRequired()
                    .HasColumnName("comDescripcion");

                entity.Property(e => e.ComDireccion)
                    .IsRequired()
                    .HasColumnName("comDireccion");

                entity.Property(e => e.ComNombre)
                    .IsRequired()
                    .HasColumnName("comNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ComProId).HasColumnName("comProId");

                entity.Property(e => e.ComUbId)
                .HasColumnName("comUbID")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

                entity.Property(e => e.ComUbicacion)
                .HasColumnName("comUbicacion")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

                entity.Property(e => e.ComUsId).HasColumnName("comUsId");

                 

                entity.HasOne(d => d.ComPro)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComProId)
                    .HasConstraintName("FK_Comercio_Producto");

                entity.HasOne(d => d.ComUb)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComUbId)
                    .HasConstraintName("FK_Comercio_Ubicacion")
                    .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);

                entity.HasOne(d => d.ComUs)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComUsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comercio_Usuario")
                    .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MaId);

                entity.Property(e => e.MaId)
                    .HasColumnName("maID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaNombre)
                    .IsRequired()
                    .HasColumnName("maNombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaId);

                entity.Property(e => e.PaId)
                    .HasColumnName("paID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaNombre)
                    .IsRequired()
                    .HasColumnName("paNombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.ParId);

                entity.Property(e => e.ParId)
                    .HasColumnName("parID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ParNombre)
                    .IsRequired()
                    .HasColumnName("parNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ParPrId).HasColumnName("parPrID");

                entity.HasOne(d => d.ParPr)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.ParPrId)
                    .HasConstraintName("FK_Partido_Partido");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.HasIndex(e => e.PerCorreo)
                    .HasName("IX_Persona_1")
                    .IsUnique();

                entity.HasIndex(e => e.PerDni)
                    .HasName("IX_Persona")
                    .IsUnique();

                entity.Property(e => e.PerId).HasColumnName("perId");

                entity.Property(e => e.PerApellido)
                    .IsRequired()
                    .HasColumnName("perApellido")
                    .HasMaxLength(50);

                entity.Property(e => e.PerCorreo)
                    .IsRequired()
                    .HasColumnName("perCorreo")
                    .HasMaxLength(50);

                entity.Property(e => e.PerDni).HasColumnName("perDNI");

                entity.Property(e => e.PerGenero)
                    .IsRequired()
                    .HasColumnName("perGenero")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PerNombre)
                    .IsRequired()
                    .HasColumnName("perNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoUsuario).HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.ProDescripcion).HasColumnName("proDescripcion");

                entity.Property(e => e.ProDisponible).HasColumnName("proDisponible");

                entity.Property(e => e.ProMaId).HasColumnName("proMaID");

                entity.Property(e => e.ProNombre)
                    .IsRequired()
                    .HasColumnName("proNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ProPrecio)
                    .HasColumnName("proPrecio")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ProMa)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ProMaId)
                    .HasConstraintName("FK_Producto_Marca");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.PrId);

                entity.Property(e => e.PrId)
                    .HasColumnName("prID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PrNombre)
                    .IsRequired()
                    .HasColumnName("prNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.PrPaId).HasColumnName("prPaID");

                entity.HasOne(d => d.PrPa)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.PrPaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Provincia_Pais");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.UbId)
                ;

                entity.Property(e => e.UbId)
                    .HasColumnName("ubID")
                    .ValueGeneratedNever()

                    ;

                entity.Property(e => e.UbParId).HasColumnName("ubParId");

                entity.Property(e => e.UbUbicacion).HasColumnName("ubUbicacion");

                entity.HasOne(d => d.UbPar)
                    .WithMany(p => p.Ubicacion)
                    .HasForeignKey(d => d.UbParId)
                    .HasConstraintName("FK_Ubicacion_Partido")
                    .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);
                  
                // agregue    .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsId);

                entity.Property(e => e.UsId).HasColumnName("usId");

                entity.Property(e => e.UsBitreg).HasColumnName("usBitreg");

                entity.Property(e => e.UsNickname)
                    .IsRequired()
                    .HasColumnName("usNickname")
                    .HasMaxLength(50);

                entity.Property(e => e.UsPassw)
                    .IsRequired()
                    .HasColumnName("usPassw")
                    .HasMaxLength(50);

                entity.Property(e => e.UsPerId).HasColumnName("usPerId");

                entity.HasOne(d => d.UsPer)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.UsPerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
