using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_FInal_Administracion_De_Sistemas.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCondominios",
                columns: table => new
                {
                    TipoCondominioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCondominios", x => x.TipoCondominioId);
                });

            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    CondominioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    TipoCondominiosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.CondominioId);
                    table.ForeignKey(
                        name: "FK_Condominios_TipoCondominios_TipoCondominiosId",
                        column: x => x.TipoCondominiosId,
                        principalTable: "TipoCondominios",
                        principalColumn: "TipoCondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Referencia = table.Column<string>(type: "TEXT", nullable: true),
                    CondominioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CondominiosCondominioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Condominios_CondominiosCondominioId",
                        column: x => x.CondominiosCondominioId,
                        principalTable: "Condominios",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CondominioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CondominiosCondominioId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientesClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_Recibos_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Condominios_CondominiosCondominioId",
                        column: x => x.CondominiosCondominioId,
                        principalTable: "Condominios",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoCondominios",
                columns: new[] { "TipoCondominioId", "Tipo" },
                values: new object[] { 1, "Apartamento" });

            migrationBuilder.InsertData(
                table: "TipoCondominios",
                columns: new[] { "TipoCondominioId", "Tipo" },
                values: new object[] { 2, "Parqueo" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CondominiosCondominioId",
                table: "Clientes",
                column: "CondominiosCondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_TipoCondominiosId",
                table: "Condominios",
                column: "TipoCondominiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClientesClienteId",
                table: "Recibos",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CondominiosCondominioId",
                table: "Recibos",
                column: "CondominiosCondominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "TipoCondominios");
        }
    }
}
