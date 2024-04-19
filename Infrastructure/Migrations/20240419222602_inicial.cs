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
                    TramiteTipoId = table.Column<int>(type: "int", nullable: false),
                    TramiteEstadoId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    { 3, "Rechazado" },
                    { 4, "Concretado" }
                });

            migrationBuilder.InsertData(
                table: "TramiteTipo",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Adopción" },
                    { 2, "Transito" }
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
