﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TramiteDbContext))]
    partial class TramiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CabeceraTramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioSolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("CabeceraTramite", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstadoId = 2,
                            FechaFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicio = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = new Guid("aaef2c4f-ded7-4b1a-add3-9a3448b9e9e0"),
                            UsuarioSolicitanteId = new Guid("19bb7f59-3372-433f-b343-00e75953d3a3")
                        },
                        new
                        {
                            Id = 2,
                            EstadoId = 2,
                            FechaFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicio = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = new Guid("aaef2c4f-ded7-4b1a-add3-9a3448b9e9e0"),
                            UsuarioSolicitanteId = new Guid("19bb7f59-3372-433f-b343-00e75953d3a3")
                        },
                        new
                        {
                            Id = 3,
                            EstadoId = 2,
                            FechaFinal = new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicio = new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = new Guid("aaef2c4f-ded7-4b1a-add3-9a3448b9e9e0"),
                            UsuarioSolicitanteId = new Guid("19bb7f59-3372-433f-b343-00e75953d3a3")
                        },
                        new
                        {
                            Id = 4,
                            EstadoId = 2,
                            FechaFinal = new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaInicio = new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UsuarioId = new Guid("aaef2c4f-ded7-4b1a-add3-9a3448b9e9e0"),
                            UsuarioSolicitanteId = new Guid("19bb7f59-3372-433f-b343-00e75953d3a3")
                        });
                });

            modelBuilder.Entity("Domain.Entities.TramiteAdopcion", b =>
                {
                    b.Property<Guid>("TramiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AireLibre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("CabeceraTramiteId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<bool>("Castrados")
                        .HasColumnType("bit");

                    b.Property<int?>("EdadHijoMenor")
                        .HasColumnType("int");

                    b.Property<bool>("HayChicos")
                        .HasColumnType("bit");

                    b.Property<bool>("HayMascotas")
                        .HasColumnType("bit");

                    b.Property<int>("HorasSolo")
                        .HasColumnType("int");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoAdopcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaseoXMes")
                        .HasColumnType("int");

                    b.Property<bool>("PropietarioInquilino")
                        .HasColumnType("bit");

                    b.Property<bool>("Vacunados")
                        .HasColumnType("bit");

                    b.HasKey("TramiteId");

                    b.HasIndex("CabeceraTramiteId")
                        .IsUnique();

                    b.ToTable("TramiteAdopcion", (string)null);

                    b.HasData(
                        new
                        {
                            TramiteId = new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"),
                            AireLibre = "Patio",
                            AnimalId = 1,
                            CabeceraTramiteId = 1,
                            CantidadPersonas = 4,
                            Castrados = true,
                            EdadHijoMenor = 10,
                            HayChicos = true,
                            HayMascotas = false,
                            HorasSolo = 1,
                            Lugar = "Casa",
                            MotivoAdopcion = "Compania Y seguridad",
                            PaseoXMes = 10,
                            PropietarioInquilino = true,
                            Vacunados = true
                        },
                        new
                        {
                            TramiteId = new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"),
                            AireLibre = "Patio",
                            AnimalId = 2,
                            CabeceraTramiteId = 2,
                            CantidadPersonas = 5,
                            Castrados = true,
                            EdadHijoMenor = 10,
                            HayChicos = true,
                            HayMascotas = false,
                            HorasSolo = 1,
                            Lugar = "Casa",
                            MotivoAdopcion = "Compañía y seguridad",
                            PaseoXMes = 10,
                            PropietarioInquilino = true,
                            Vacunados = true
                        },
                        new
                        {
                            TramiteId = new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"),
                            AireLibre = "Jardín",
                            AnimalId = 3,
                            CabeceraTramiteId = 3,
                            CantidadPersonas = 2,
                            Castrados = true,
                            HayChicos = false,
                            HayMascotas = false,
                            HorasSolo = 2,
                            Lugar = "Casa",
                            MotivoAdopcion = "Compañía y entretenimiento",
                            PaseoXMes = 15,
                            PropietarioInquilino = false,
                            Vacunados = true
                        },
                        new
                        {
                            TramiteId = new Guid("d0940fb6-b3a3-4c14-ad0c-d565be450f1c"),
                            AireLibre = "Patio grande",
                            AnimalId = 4,
                            CabeceraTramiteId = 4,
                            CantidadPersonas = 6,
                            Castrados = false,
                            EdadHijoMenor = 12,
                            HayChicos = true,
                            HayMascotas = false,
                            HorasSolo = 2,
                            Lugar = "Casa",
                            MotivoAdopcion = "Compañía y cuidado",
                            PaseoXMes = 20,
                            PropietarioInquilino = false,
                            Vacunados = true
                        });
                });

            modelBuilder.Entity("Domain.Entities.TramiteEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TramiteEstado", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Aprobado"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Revisión"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Rechazado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TramiteTransito", b =>
                {
                    b.Property<Guid>("TramiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CabeceraTramiteId")
                        .HasColumnType("int");

                    b.Property<string>("Cantidadpersonas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChicosYEdad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisponibilidadHoraria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emergencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expectativa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExperienciaDeTransito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HayMascotas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManejoAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedioDeTransporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliticaOrganizacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropietarioInquilino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonInteres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rutina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seguimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiempoDeAcogida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeEspacio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VacunadosCastrados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TramiteId");

                    b.HasIndex("CabeceraTramiteId")
                        .IsUnique();

                    b.ToTable("TramiteTransito", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CabeceraTramite", b =>
                {
                    b.HasOne("Domain.Entities.TramiteEstado", "Estado")
                        .WithMany("CabeceraTramite")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Domain.Entities.TramiteAdopcion", b =>
                {
                    b.HasOne("Domain.Entities.CabeceraTramite", "CabeceraTramite")
                        .WithOne("TramiteAdopcion")
                        .HasForeignKey("Domain.Entities.TramiteAdopcion", "CabeceraTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabeceraTramite");
                });

            modelBuilder.Entity("Domain.Entities.TramiteTransito", b =>
                {
                    b.HasOne("Domain.Entities.CabeceraTramite", "CabeceraTramite")
                        .WithOne("TramiteTransito")
                        .HasForeignKey("Domain.Entities.TramiteTransito", "CabeceraTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabeceraTramite");
                });

            modelBuilder.Entity("Domain.Entities.CabeceraTramite", b =>
                {
                    b.Navigation("TramiteAdopcion")
                        .IsRequired();

                    b.Navigation("TramiteTransito")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.TramiteEstado", b =>
                {
                    b.Navigation("CabeceraTramite");
                });
#pragma warning restore 612, 618
        }
    }
}
