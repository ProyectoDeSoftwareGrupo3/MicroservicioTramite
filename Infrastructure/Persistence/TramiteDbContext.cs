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

            modelBuilder.Entity<Tramite>().HasData(
                new Tramite
                {
                    Id=1,
                    AnimalId = 1,
                    EdadHijoMenor=10,
                    AireLibre="Patio",
                    Cantidadpersonas=4,
                    Castrados=true,
                    Chicos=true,
                    FechaInicio=DateTime.Now,
                    HayAnimales=true,
                    HorasSolo = 4,
                    LugarAdopcion = "Casa",
                    MotivoAdopcion="Compania",
                    PaseoMes=10,
                    PropietarioInquilino=true,
                    TramiteEstadoId=2,
                    TramiteTipoId=1,
                    UsuarioAdoptanteId=1,
                    UsuarioId=Guid.NewGuid(),
                    Vacunados=true,
                }
                );
            modelBuilder.Entity<Tramite>().HasData(
                new Tramite
                {
                    Id = 2,
                    AnimalId = 2,
                    EdadHijoMenor = 0,
                    AireLibre = "No posee",
                    Cantidadpersonas = 4,
                    Castrados = false,
                    Chicos = true,
                    FechaInicio = new DateTime(2024,5,10),
                    FechaFinalizacion = new DateTime(2024, 10, 10),
                    HayAnimales = false,
                    HorasSolo = 2,
                    LugarAdopcion = "Casa",
                    MotivoAdopcion = "Compania",
                    PaseoMes = 10,
                    PropietarioInquilino = true,
                    TramiteEstadoId = 1,
                    TramiteTipoId = 1,
                    UsuarioAdoptanteId = 2,
                    UsuarioId = Guid.NewGuid(),
                    Vacunados = false,
                }
                );
            modelBuilder.Entity<Tramite>().HasData(
                new Tramite
                {
                    Id = 3,
                    AnimalId = 3,
                    EdadHijoMenor = 10,
                    AireLibre = "Granja",
                    Cantidadpersonas = 4,
                    Castrados = true,
                    Chicos = true,
                    FechaInicio = new DateTime(2024,2,12),
                    HayAnimales = true,
                    HorasSolo = 4,
                    LugarAdopcion = "Granja",
                    MotivoAdopcion = "Vigilancia",
                    PaseoMes = 5,
                    PropietarioInquilino = true,
                    TramiteEstadoId = 3,
                    TramiteTipoId = 1,
                    UsuarioAdoptanteId = 4,
                    UsuarioId = Guid.NewGuid(),
                    Vacunados = true,
                }
                );
            modelBuilder.Entity<Tramite>().HasData(
                new Tramite
                {
                    Id = 4,
                    AnimalId = 4,
                    EdadHijoMenor = 0,
                    AireLibre = "no posee",
                    Cantidadpersonas = 2,
                    Castrados = false,
                    Chicos = false,
                    FechaInicio = new DateTime(2024, 1,26),
                    HayAnimales = false,
                    HorasSolo = 4,
                    LugarAdopcion = "Casa",
                    MotivoAdopcion = "Vigilancia",
                    PaseoMes = 4,
                    PropietarioInquilino = false,
                    TramiteEstadoId = 2,
                    TramiteTipoId = 1,
                    UsuarioAdoptanteId = 4,
                    UsuarioId = Guid.NewGuid(),
                    Vacunados = false,
                }
                );
            modelBuilder.Entity<Tramite>().HasData(
                new Tramite
                {
                    Id = 5,
                    AnimalId = 5,
                    EdadHijoMenor = 10,
                    AireLibre = "Patio",
                    Cantidadpersonas = 4,
                    Castrados = true,
                    Chicos = true,
                    FechaInicio = new DateTime(2024,4,13),
                    HayAnimales = true,
                    HorasSolo = 4,
                    LugarAdopcion = "Casa",
                    MotivoAdopcion = "Compania",
                    PaseoMes = 10,
                    PropietarioInquilino = true,
                    TramiteEstadoId = 2,
                    TramiteTipoId = 2,
                    UsuarioAdoptanteId = 4,
                    UsuarioId = Guid.NewGuid(),
                    Vacunados = true,
                }
                );

        }

    }
}
