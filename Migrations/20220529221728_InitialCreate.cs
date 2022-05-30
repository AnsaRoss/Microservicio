using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicioMovimientos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_persona", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cliente_tb_persona_personaId",
                        column: x => x.personaId,
                        principalTable: "tb_persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cuenta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saldoInicial = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cuenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_cuenta_tb_cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "tb_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_movimiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<double>(type: "float", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false),
                    cuentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_movimiento_tb_cuenta_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "tb_cuenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_personaId",
                table: "tb_cliente",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cuenta_clienteId",
                table: "tb_cuenta",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movimiento_cuentaId",
                table: "tb_movimiento",
                column: "cuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_movimiento");

            migrationBuilder.DropTable(
                name: "tb_cuenta");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_persona");
        }
    }
}
