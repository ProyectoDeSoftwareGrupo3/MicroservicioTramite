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

            modelBuilder.Entity("Domain.Entities.Tramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AireLibre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidadpersonas")
                        .HasColumnType("int");

                    b.Property<bool>("Castrados")
                        .HasColumnType("bit");

                    b.Property<bool>("Chicos")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HayAnimales")
                        .HasColumnType("bit");

                    b.Property<int>("HorasSolo")
                        .HasColumnType("int");

                    b.Property<string>("LugarAdopcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoAdopcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaseoMes")
                        .HasColumnType("int");

                    b.Property<bool>("PropietarioInquilino")
                        .HasColumnType("bit");

                    b.Property<int>("TramiteEstadoId")
                        .HasColumnType("int");

                    b.Property<int>("TramiteTipoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioAdoptanteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Vacunados")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TramiteEstadoId");

                    b.HasIndex("TramiteTipoId");

                    b.ToTable("Tramite", (string)null);
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
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Concretado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TramiteTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TramiteTipo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Adopción"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Transito"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Tramite", b =>
                {
                    b.HasOne("Domain.Entities.TramiteEstado", "TramiteEstado")
                        .WithMany("Tramites")
                        .HasForeignKey("TramiteEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TramiteTipo", "TramiteTipo")
                        .WithMany("Tramites")
                        .HasForeignKey("TramiteTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TramiteEstado");

                    b.Navigation("TramiteTipo");
                });

            modelBuilder.Entity("Domain.Entities.TramiteEstado", b =>
                {
                    b.Navigation("Tramites");
                });

            modelBuilder.Entity("Domain.Entities.TramiteTipo", b =>
                {
                    b.Navigation("Tramites");
                });
#pragma warning restore 612, 618
        }
    }
}
