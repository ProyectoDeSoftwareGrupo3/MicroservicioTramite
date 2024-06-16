using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PaseoXMes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteAdopcion", x => x.TramiteId);
                });

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
                    PoliticaOrganizacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteTransito", x => x.TramiteId);
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
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TramiteAdopcionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TramiteTransitoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabeceraTramite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabeceraTramite_TramiteAdopcion_TramiteAdopcionId",
                        column: x => x.TramiteAdopcionId,
                        principalTable: "TramiteAdopcion",
                        principalColumn: "TramiteId");
                    table.ForeignKey(
                        name: "FK_CabeceraTramite_TramiteEstado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TramiteEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabeceraTramite_TramiteTransito_TramiteTransitoId",
                        column: x => x.TramiteTransitoId,
                        principalTable: "TramiteTransito",
                        principalColumn: "TramiteId");
                });

            migrationBuilder.InsertData(
                table: "TramiteAdopcion",
                columns: new[] { "TramiteId", "AireLibre", "CantidadPersonas", "Castrados", "EdadHijoMenor", "HayChicos", "HayMascotas", "HorasSolo", "MotivoAdopcion", "PaseoXMes", "PropietarioInquilino", "Vacunados" },
                values: new object[,]
                {
                    { new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"), "Patio", 4, true, 10, true, false, 1, "Compania Y seguridad", 10, true, true },
                    { new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"), "Patio", 5, true, 10, true, false, 1, "Compañía y seguridad", 10, true, true },
                    { new Guid("d0940fb6-b3a3-4c14-ad0c-d565be450f1c"), "Patio grande", 6, false, 12, true, false, 2, "Compañía y cuidado", 20, false, true },
                    { new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"), "Jardín", 2, true, null, false, false, 2, "Compañía y entretenimiento", 15, false, true }
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
                table: "TramiteTransito",
                columns: new[] { "TramiteId", "ActitudHaciaAnimales", "Cantidadpersonas", "ChicosYEdad", "DisponibilidadHoraria", "Emergencia", "Expectativa", "ExperienciaDeTransito", "HayMascotas", "ManejoAnimal", "MedioDeTransporte", "PoliticaOrganizacion", "PropietarioInquilino", "RazonInteres", "Rutina", "Seguimiento", "TiempoDeAcogida", "TipoDeEspacio", "VacunadosCastrados" },
                values: new object[,]
                {
                    { new Guid("5c0c5be5-f32d-4743-87ab-9f025c09811f"), "B ", 4, " B", "B ", "B ", "B ", "B", " B", "B ", "B ", "B ", "B ", "B", "B ", "B ", "B ", "B ", "B " },
                    { new Guid("60d354f6-375b-4c3f-a94b-8aaed89303d4"), " C", 4, " C", "C ", "C ", "C ", " C", " C", "C ", " C", "C ", "C ", " C", "C ", " C", "C ", "C ", "C " },
                    { new Guid("74730c71-9150-42d9-a087-56bbccad1c79"), "A", 4, "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A" },
                    { new Guid("a7e82c64-529e-4add-a922-7f845d306eb6"), "D ", 4, "D ", "D ", "D ", "D ", "D ", "D ", "D ", " D", "D ", "D ", " D", "D ", "D ", "D ", "D ", "D " }
                });

            migrationBuilder.InsertData(
                table: "CabeceraTramite",
                columns: new[] { "Id", "AnimalId", "EstadoId", "FechaFinal", "FechaInicio", "TramiteAdopcionId", "TramiteTransitoId", "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"), null, new Guid("07c32251-5f12-4cfb-b8b6-25fbbfb3b883"), new Guid("d3bb6c68-0b36-47f8-872d-cb364441f773") },
                    { 2, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"), null, new Guid("f3f4e412-04c1-4af1-8f4f-9a320cc6b4fc"), new Guid("8441c475-e0b6-4ec1-88d6-b8fc8f4a309b") },
                    { 3, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"), null, new Guid("9c91b132-b88b-4824-9991-3ce69155e6ab"), new Guid("c0c5f5d8-006c-4b59-b4d7-70c3b04871d0") },
                    { 4, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("74730c71-9150-42d9-a087-56bbccad1c79"), new Guid("06dd8e49-b48e-4362-8c75-ab7304f05284"), new Guid("bc348cff-61d6-4063-8a3a-3f6619b34127") },
                    { 5, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c0c5be5-f32d-4743-87ab-9f025c09811f"), new Guid("38fbe731-341e-412f-a9ad-f6d3dd41aef3"), new Guid("991bbb4e-ebca-4c37-9bf5-fd2a2b7e663b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabeceraTramite_EstadoId",
                table: "CabeceraTramite",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CabeceraTramite_TramiteAdopcionId",
                table: "CabeceraTramite",
                column: "TramiteAdopcionId",
                unique: true,
                filter: "[TramiteAdopcionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CabeceraTramite_TramiteTransitoId",
                table: "CabeceraTramite",
                column: "TramiteTransitoId",
                unique: true,
                filter: "[TramiteTransitoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabeceraTramite");

            migrationBuilder.DropTable(
                name: "TramiteAdopcion");

            migrationBuilder.DropTable(
                name: "TramiteEstado");

            migrationBuilder.DropTable(
                name: "TramiteTransito");
        }
    }
}
