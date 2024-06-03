using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class TramiteDbContext : DbContext
    {
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<TramiteTipo> TramiteTipos { get; set; }
        public DbSet<TramiteEstado> TramiteEstados { get; set; }

        public TramiteDbContext(DbContextOptions<TramiteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TramiteTipo>(entity =>
            {
                entity.ToTable("TramiteTipo");
                entity.HasKey(tt => tt.Id);
                entity.Property(tt => tt.Id).ValueGeneratedOnAdd();
                entity.Property(tt => tt.Descripcion).IsRequired();

                entity.HasMany(tt => tt.Tramites)
                .WithOne(t => t.TramiteTipo);
            });
            modelBuilder.Entity<TramiteEstado>(entity =>
            {
                entity.ToTable("TramiteEstado");
                entity.HasKey(te => te.Id);
                entity.Property(te => te.Id).ValueGeneratedOnAdd();
                entity.Property(te => te.Descripcion).IsRequired();

                entity.HasMany(tt => tt.Tramites)
                .WithOne(t => t.TramiteEstado);
            });
            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.ToTable("Tramite");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                

                entity.HasOne(tt => tt.TramiteTipo)
                .WithMany(t => t.Tramites)
                .HasForeignKey(t => t.TramiteTipoId);

                entity.HasOne(te => te.TramiteEstado)
                .WithMany(t => t.Tramites)
                .HasForeignKey(t => t.TramiteEstadoId);
            });

            modelBuilder.Entity<TramiteEstado>().HasData(
                new TramiteEstado
                {
                    Id = 1,
                    Descripcion = "Aprobado"
                },
                new TramiteEstado
                {
                    Id = 2,
                    Descripcion = "Revisión"
                },
                new TramiteEstado
                {
                    Id = 3,
                    Descripcion = "Rechazado"
                },
                new TramiteEstado
                {
                    Id = 4,
                    Descripcion = "Concretado"
                }
                );

            modelBuilder.Entity<TramiteTipo>().HasData(
                new TramiteTipo
                {
                    Id = 1,
                    Descripcion = "Adopción"
                },
                new TramiteTipo
                {
                    Id = 2,
                    Descripcion = "Transito"
                }
                );
        }

    }
}
