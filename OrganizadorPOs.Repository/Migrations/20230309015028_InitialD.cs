using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorPOs.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Projeto = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    WWC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HORAS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeitoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ValorPO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RecebidaEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmitiuNotaFiscal = table.Column<bool>(type: "bit", nullable: false),
                    PagamentoRecebido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");
        }
    }
}
