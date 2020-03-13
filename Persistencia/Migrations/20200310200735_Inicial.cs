using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    CartaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    BandeiraCartao = table.Column<string>(nullable: true),
                    Limite = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.CartaoId);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    DespesaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Pago = table.Column<bool>(nullable: false),
                    DespesaFixa = table.Column<bool>(nullable: false),
                    DespesaParcelada = table.Column<bool>(nullable: false),
                    QtdParcelas = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    DhDespesa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.DespesaId);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    ReceitaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Pago = table.Column<bool>(nullable: false),
                    ReceitaFixa = table.Column<bool>(nullable: false),
                    ReceitaParcelada = table.Column<bool>(nullable: false),
                    QtdParcelas = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    DhReceita = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.ReceitaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DhTimestamp = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
