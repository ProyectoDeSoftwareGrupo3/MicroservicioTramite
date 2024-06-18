using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TramitesActualizados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TramiteEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabeceraTramite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAdoptanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabeceraTramite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabeceraTramite_TramiteEstado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TramiteEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TramiteAdopcion",
                columns: table => new
                {
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    HayChicos = table.Column<bool>(type: "bit", nullable: false),
                    EdadHijoMenor = table.Column<int>(type: "int", nullable: true),
                    HayMascotas = table.Column<bool>(type: "bit", nullable: false),
                    Vacunados = table.Column<bool>(type: "bit", nullable: false),
                    Castrados = table.Column<bool>(type: "bit", nullable: false),
                    PropietarioInquilino = table.Column<bool>(type: "bit", nullable: false),
                    AireLibre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoAdopcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasSolo = table.Column<int>(type: "int", nullable: false),
                    PaseoXMes = table.Column<int>(type: "int", nullable: false),
                    CabeceraTramiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteAdopcion", x => x.TramiteId);
                    table.ForeignKey(
                        name: "FK_TramiteAdopcion_CabeceraTramite_CabeceraTramiteId",
                        column: x => x.CabeceraTramiteId,
                        principalTable: "CabeceraTramite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TramiteTransito",
                columns: table => new
                {
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazonInteres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaDeTransito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidadpersonas = table.Column<int>(type: "int", nullable: false),
                    ActitudHaciaAnimales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChicosYEdad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HayMascotas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacunadosCastrados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeEspacio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropietarioInquilino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisponibilidadHoraria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rutina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedioDeTransporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seguimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManejoAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoDeAcogida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expectativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliticaOrganizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabeceraTramiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteTransito", x => x.TramiteId);
                    table.ForeignKey(
                        name: "FK_TramiteTransito_CabeceraTramite_CabeceraTramiteId",
                        column: x => x.CabeceraTramiteId,
                        principalTable: "CabeceraTramite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TramiteEstado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Aprobado" },
                    { 2, "Revisión" },
                    { 3, "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "CabeceraTramite",
                columns: new[] { "Id", "AnimalId", "EstadoId", "FechaFinal", "FechaInicio", "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e6fbddc1-85d1-404d-9126-e5541bd58215"), new Guid("726d8bfe-ac8c-44b6-a36a-f8ad3c37d9da") },
                    { 2, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("835dea1a-fbed-4fa7-b93e-3236aeef016e"), new Guid("4b3164a6-3ed2-4649-8d2f-3f4ad9082404") },
                    { 3, 3, 1, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af950ea6-1217-464c-87b4-f24edad2a0b1"), new Guid("0a74eb49-e078-4999-9d2b-bf522ca7ec76") },
                    { 4, 4, 1, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c3042df8-6748-4378-908a-cde9c6f7a954"), new Guid("0518c7d3-4332-46df-8cb5-0db4d51c81b6") },
                    { 5, 5, 3, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4ead837a-2562-4a69-9e49-e43649333386"), new Guid("ce3023ac-1523-49be-a71d-315d6a38ae02") }
                });

            migrationBuilder.InsertData(
                table: "TramiteAdopcion",
                columns: new[] { "TramiteId", "AireLibre", "CabeceraTramiteId", "CantidadPersonas", "Castrados", "EdadHijoMenor", "HayChicos", "HayMascotas", "HorasSolo", "MotivoAdopcion", "PaseoXMes", "PropietarioInquilino", "Vacunados" },
                values: new object[,]
                {
                    { new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"), "Patio", 1, 4, true, 10, true, false, 1, "Compania Y seguridad", 10, true, true },
                    { new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"), "Patio", 2, 5, true, 10, true, false, 1, "Compañía y seguridad", 10, true, true },
                    { new Guid("d0940fb6-b3a3-4c14-ad0c-d565be450f1c"), "Patio grande", 4, 6, false, 12, true, false, 2, "Compañía y cuidado", 20, false, true },
                    { new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"), "Jardín", 3, 2, true, null, false, false, 2, "Compañía y entretenimiento", 15, false, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabeceraTramite_EstadoId",
                table: "CabeceraTramite",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TramiteAdopcion_CabeceraTramiteId",
                table: "TramiteAdopcion",
                column: "CabeceraTramiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TramiteTransito_CabeceraTramiteId",
                table: "TramiteTransito",
                column: "CabeceraTramiteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TramiteAdopcion");

            migrationBuilder.DropTable(
                name: "TramiteTransito");

            migrationBuilder.DropTable(
                name: "CabeceraTramite");

            migrationBuilder.DropTable(
                name: "TramiteEstado");
        }
    }
}
