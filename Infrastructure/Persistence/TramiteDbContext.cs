using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class TramiteDbContext : DbContext
    {
        public DbSet<CabeceraTramite> CabeceraTramites { get; set; }
        public DbSet<TramiteAdopcion> TramiteAdopciones { get; set; }
        public DbSet<TramiteEstado> TramiteEstados { get; set; }
        public DbSet<TramiteTransito> TramiteTransitos { get; set; }


        public TramiteDbContext(DbContextOptions<TramiteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TramiteEstado>(entity =>
            {
                entity.ToTable("TramiteEstado");
                entity.HasKey(te => te.Id);
                entity.Property(te => te.Id).ValueGeneratedOnAdd();
                entity.Property(te => te.Descripcion).IsRequired();

                entity.HasMany(te => te.CabeceraTramite)
                    .WithOne(ct => ct.Estado);


            });
            modelBuilder.Entity<TramiteTransito>(entity =>
            {
                entity.ToTable("TramiteTransito");
                entity.HasKey(tt => tt.TramiteId);
                entity.Property(tt => tt.TramiteId).ValueGeneratedOnAdd();
                                
            });
            modelBuilder.Entity<TramiteAdopcion>(entity =>
            {
                entity.ToTable("TramiteAdopcion");
                entity.HasKey(ta => ta.TramiteId);
                entity.Property(ta => ta.TramiteId).ValueGeneratedOnAdd();
                    
            });
            modelBuilder.Entity<CabeceraTramite>(entity =>
            {
                entity.ToTable("CabeceraTramite");
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Id).ValueGeneratedOnAdd();

                entity.Property(ct => ct.UsuarioId).IsRequired();
                entity.Property(ct => ct.AnimalId).IsRequired();
                entity.Property(ct => ct.FechaInicio).IsRequired();
                entity.Property(ct => ct.EstadoId).IsRequired();


                entity.HasOne(ct => ct.Estado)
                    .WithMany(e => e.CabeceraTramite)
                    .HasForeignKey(ct => ct.EstadoId);      

                entity.HasOne(s => s.TramiteAdopcion)
                    .WithOne(sa => sa.CabeceraTramite)
                    .HasForeignKey<TramiteAdopcion>(sas => sas.CabeceraTramiteId);
                entity.HasOne(s => s.TramiteTransito)
                    .WithOne(sa => sa.CabeceraTramite)
                    .HasForeignKey<TramiteTransito>(sas => sas.CabeceraTramiteId);
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
            modelBuilder.Entity<TramiteAdopcion>().HasData(
                new TramiteAdopcion
                {
                    TramiteId = new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"),
                    CantidadPersonas = 4,
                    HayChicos = true,
                    EdadHijoMenor = 10,
                    HayMascotas = false,
                    Vacunados = true,
                    Castrados = true,
                    Lugar = "Casa",
                    PropietarioInquilino = true,
                    AireLibre = "Patio",
                    MotivoAdopcion = "Compania Y seguridad",
                    HorasSolo = 1,
                    PaseoXMes = 10,
                    CabeceraTramiteId = 1
                },
                new TramiteAdopcion
                {
                    TramiteId = new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"),
                    CantidadPersonas = 5,
                    HayChicos = true,
                    EdadHijoMenor = 10,
                    HayMascotas = false,
                    Vacunados = true,
                    Castrados = true,
                    Lugar = "Casa",
                    PropietarioInquilino = true,
                    AireLibre = "Patio",
                    MotivoAdopcion = "Compañía y seguridad",
                    HorasSolo = 1,
                    PaseoXMes = 10,
                    CabeceraTramiteId = 2
                },
                new TramiteAdopcion
                {
                    TramiteId = new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"),
                    CantidadPersonas = 2,
                    HayChicos = false,
                    EdadHijoMenor = null,
                    HayMascotas = false,
                    Vacunados = true,
                    Castrados = true,
                    Lugar = "Casa",
                    PropietarioInquilino = false,
                    AireLibre = "Jardín",
                    MotivoAdopcion = "Compañía y entretenimiento",
                    HorasSolo = 2,
                    PaseoXMes = 15,
                    CabeceraTramiteId = 3
                },

                new TramiteAdopcion
                {
                    TramiteId = new Guid("d0940fb6-b3a3-4c14-ad0c-d565be450f1c"),
                    CantidadPersonas = 6,
                    HayChicos = true,
                    EdadHijoMenor = 12,
                    HayMascotas = false,
                    Vacunados = true,
                    Castrados = false,
                    Lugar = "Casa",
                    PropietarioInquilino = false,
                    AireLibre = "Patio grande",
                    MotivoAdopcion = "Compañía y cuidado",
                    HorasSolo = 2,
                    PaseoXMes = 20,
                    CabeceraTramiteId = 4
                }
                );



            // modelBuilder.Entity<TramiteTransito>().HasData(
            //     new TramiteTransito
            //     {
            //         TramiteId = new Guid("74730c71-9150-42d9-a087-56bbccad1c79"),
            //         RazonInteres = "A",
            //         ExperienciaDeTransito = "A",
            //         Cantidadpersonas = 4,
            //         ActitudHaciaAnimales = "A",
            //         ChicosYEdad = "A",
            //         HayMascotas = "A",
            //         VacunadosCastrados = "A",
            //         TipoDeEspacio = "A",
            //         PropietarioInquilino = "A",
            //         DisponibilidadHoraria = "A",
            //         Rutina = "A",
            //         Emergencia = "A",
            //         MedioDeTransporte = "A",
            //         Seguimiento = "A",
            //         ManejoAnimal = "A",
            //         TiempoDeAcogida = "A",
            //         Expectativa = "A",
            //         PoliticaOrganizacion = "A"

            //     },

            //     new TramiteTransito
            //     {
            //         TramiteId = new Guid("5c0c5be5-f32d-4743-87ab-9f025c09811f"),
            //         RazonInteres = "B",
            //         ExperienciaDeTransito = "B",
            //         Cantidadpersonas = 4,
            //         ActitudHaciaAnimales = "B ",
            //         ChicosYEdad = " B",
            //         HayMascotas = " B",
            //         VacunadosCastrados = "B ",
            //         TipoDeEspacio = "B ",
            //         PropietarioInquilino = "B ",
            //         DisponibilidadHoraria = "B ",
            //         Rutina = "B ",
            //         Emergencia = "B ",
            //         MedioDeTransporte = "B ",
            //         Seguimiento = "B ",
            //         ManejoAnimal = "B ",
            //         TiempoDeAcogida = "B ",
            //         Expectativa = "B ",
            //         PoliticaOrganizacion = "B "

            //     },

            //     new TramiteTransito
            //     {
            //         TramiteId = new Guid("60d354f6-375b-4c3f-a94b-8aaed89303d4"),
            //         RazonInteres = " C",
            //         ExperienciaDeTransito = " C",
            //         Cantidadpersonas = 4,
            //         ActitudHaciaAnimales = " C",
            //         ChicosYEdad = " C",
            //         HayMascotas = " C",
            //         VacunadosCastrados = "C ",
            //         TipoDeEspacio = "C ",
            //         PropietarioInquilino = "C ",
            //         DisponibilidadHoraria = "C ",
            //         Rutina = "C ",
            //         Emergencia = "C ",
            //         MedioDeTransporte = " C",
            //         Seguimiento = " C",
            //         ManejoAnimal = "C ",
            //         TiempoDeAcogida = "C ",
            //         Expectativa = "C ",
            //         PoliticaOrganizacion = "C "

            //     },

            //     new TramiteTransito
            //     {
            //         TramiteId = new Guid("a7e82c64-529e-4add-a922-7f845d306eb6"),
            //         RazonInteres = " D",
            //         ExperienciaDeTransito = "D ",
            //         Cantidadpersonas = 4,
            //         ActitudHaciaAnimales = "D ",
            //         ChicosYEdad = "D ",
            //         HayMascotas = "D ",
            //         VacunadosCastrados = "D ",
            //         TipoDeEspacio = "D ",
            //         PropietarioInquilino = "D ",
            //         DisponibilidadHoraria = "D ",
            //         Rutina = "D ",
            //         Emergencia = "D ",
            //         MedioDeTransporte = " D",
            //         Seguimiento = "D ",
            //         ManejoAnimal = "D ",
            //         TiempoDeAcogida = "D ",
            //         Expectativa = "D ",
            //         PoliticaOrganizacion = "D "

            //     }

            //     );

            modelBuilder.Entity<CabeceraTramite>().HasData(
                new CabeceraTramite
                {
                    Id = 1,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAdoptanteId = Guid.NewGuid(),
                    AnimalId = 1,
                    FechaInicio = new DateTime(2024, 3, 12),
                    EstadoId = 2,                    
                },
                new CabeceraTramite
                {
                    Id = 2,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAdoptanteId = Guid.NewGuid(),
                    AnimalId = 2,
                    FechaInicio = new DateTime(2024, 4, 12),
                    EstadoId = 2,                    


                },
                new CabeceraTramite
                {
                    Id = 3,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAdoptanteId = Guid.NewGuid(),
                    AnimalId = 3,
                    FechaInicio = new DateTime(2024, 5, 12),
                    FechaFinal = new DateTime(2024, 5, 13),
                    EstadoId = 1,                    


                },
                new CabeceraTramite
                {
                    Id = 4,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAdoptanteId = Guid.NewGuid(),
                    AnimalId = 4,
                    FechaInicio = new DateTime(2024, 6, 12),
                    FechaFinal = new DateTime(2024, 6, 13),
                    EstadoId = 1,                   
                },
                new CabeceraTramite
                {
                    Id = 5,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAdoptanteId = Guid.NewGuid(),
                    AnimalId = 5,
                    FechaInicio = new DateTime(2024, 6, 12),
                    FechaFinal = new DateTime(2024, 6, 13),
                    EstadoId = 3,                    
                }
                );





        }

    }
}
