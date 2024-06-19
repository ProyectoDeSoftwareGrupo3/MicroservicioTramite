using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TramiteACtualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lugar",
                table: "TramiteAdopcion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("185f2e1a-e95f-4c22-b6c3-c86d2a5d7638"), new Guid("50303067-824d-4eb8-b8a0-49fab7ee9807") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("681ce6b6-d8f4-477a-8cc8-eeacabd8053c"), new Guid("79f2e44f-2ae3-4251-9e66-da1f021f9665") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("09948fdb-7bd2-46bd-9559-4c4925bc3ca9"), new Guid("1185253f-ef42-4972-bd8e-0e8c39749e51") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("53504921-5ee0-44b0-ac6e-1361d0ad0b48"), new Guid("dd6161fb-4fcd-4872-8f74-9600d42bb911") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("52d58175-21d9-4fd5-8b6d-31938dfdfa29"), new Guid("e6f5d921-01a2-4c4b-b92e-f893d84b9cbe") });

            migrationBuilder.UpdateData(
                table: "TramiteAdopcion",
                keyColumn: "TramiteId",
                keyValue: new Guid("54af2b5e-b9fb-405e-8520-3d79af6b1a8d"),
                column: "Lugar",
                value: "Casa");

            migrationBuilder.UpdateData(
                table: "TramiteAdopcion",
                keyColumn: "TramiteId",
                keyValue: new Guid("7e6066d1-7754-44e7-9758-706bdc60a88a"),
                column: "Lugar",
                value: "Casa");

            migrationBuilder.UpdateData(
                table: "TramiteAdopcion",
                keyColumn: "TramiteId",
                keyValue: new Guid("d0940fb6-b3a3-4c14-ad0c-d565be450f1c"),
                column: "Lugar",
                value: "Casa");

            migrationBuilder.UpdateData(
                table: "TramiteAdopcion",
                keyColumn: "TramiteId",
                keyValue: new Guid("e2780dbb-17dc-44dd-97f0-4a01a5b4ae86"),
                column: "Lugar",
                value: "Casa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lugar",
                table: "TramiteAdopcion");

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("e6fbddc1-85d1-404d-9126-e5541bd58215"), new Guid("726d8bfe-ac8c-44b6-a36a-f8ad3c37d9da") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("835dea1a-fbed-4fa7-b93e-3236aeef016e"), new Guid("4b3164a6-3ed2-4649-8d2f-3f4ad9082404") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("af950ea6-1217-464c-87b4-f24edad2a0b1"), new Guid("0a74eb49-e078-4999-9d2b-bf522ca7ec76") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("c3042df8-6748-4378-908a-cde9c6f7a954"), new Guid("0518c7d3-4332-46df-8cb5-0db4d51c81b6") });

            migrationBuilder.UpdateData(
                table: "CabeceraTramite",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "UsuarioAdoptanteId", "UsuarioId" },
                values: new object[] { new Guid("4ead837a-2562-4a69-9e49-e43649333386"), new Guid("ce3023ac-1523-49be-a71d-315d6a38ae02") });
        }
    }
}
