using System;
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
                name: "TramiteTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tramite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAdoptanteId = table.Column<int>(type: "int", nullable: false),
                    Chicos = table.Column<bool>(type: "bit", nullable: false),
                    EdadHijoMenor = table.Column<int>(type: "int", nullable: false),
                    Cantidadpersonas = table.Column<int>(type: "int", nullable: false),
                    HayAnimales = table.Column<bool>(type: "bit", nullable: false),
                    Vacunados = table.Column<bool>(type: "bit", nullable: false),
                    Castrados = table.Column<bool>(type: "bit", nullable: false),
                    LugarAdopcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropietarioInquilino = table.Column<bool>(type: "bit", nullable: false),
                    AireLibre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoAdopcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasSolo = table.Column<int>(type: "int", nullable: false),
                    PaseoMes = table.Column<int>(type: "int", nullable: false),
                    TramiteTipoId = table.Column<int>(type: "int", nullable: false),
                    TramiteEstadoId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramite_TramiteEstado_TramiteEstadoId",
                        column: x => x.TramiteEstadoId,
                        principalTable: "TramiteEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tramite_TramiteTipo_TramiteTipoId",
                        column: x => x.TramiteTipoId,
                        principalTable: "TramiteTipo",
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
                table: "TramiteTipo",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Adopción" },
                    { 2, "Transito" }
                });

            migrationBuilder.InsertData(
                table: "Tramite",
                columns: new[] { "Id", "AireLibre", "AnimalId", "Cantidadpersonas", "Castrados", "Chicos", "EdadHijoMenor", "FechaFinalizacion", "FechaInicio", "HayAnimales", "HorasSolo", "LugarAdopcion", "MotivoAdopcion", "PaseoMes", "PropietarioInquilino", "TramiteEstadoId", "TramiteTipoId", "UsuarioAdoptanteId", "UsuarioId", "Vacunados" },
                values: new object[,]
                {
                    { 1, "Patio", 1, 4, true, true, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 17, 31, 11, 657, DateTimeKind.Local).AddTicks(2457), true, 4, "Casa", "Compania", 10, true, 2, 1, 1, new Guid("bf825f14-9af5-458c-9339-3e789a17a88c"), true },
                    { 2, "No posee", 2, 4, false, true, 0, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "Casa", "Compania", 10, true, 1, 1, 2, new Guid("f60a95b7-dcdc-4b96-aa63-0cd6bafdff29"), false },
                    { 3, "Granja", 3, 4, true, true, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, "Granja", "Vigilancia", 5, true, 3, 1, 4, new Guid("111c5b95-d813-4070-a625-0ddbfc8bc797"), true },
                    { 4, "no posee", 4, 2, false, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "Casa", "Vigilancia", 4, false, 2, 1, 4, new Guid("1af2a1e5-179a-4d93-8b89-b8989a03cd58"), false },
                    { 5, "Patio", 5, 4, true, true, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, "Casa", "Compania", 10, true, 2, 2, 4, new Guid("80898b3b-e900-436d-b37a-04206aecd84c"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_TramiteEstadoId",
                table: "Tramite",
                column: "TramiteEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramite_TramiteTipoId",
                table: "Tramite",
                column: "TramiteTipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramite");

            migrationBuilder.DropTable(
                name: "TramiteEstado");

            migrationBuilder.DropTable(
                name: "TramiteTipo");
        }
    }
}
