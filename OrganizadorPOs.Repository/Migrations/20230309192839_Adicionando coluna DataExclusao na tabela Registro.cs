using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorPOs.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandocolunaDataExclusaonatabelaRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Registros",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Registros");
        }
    }
}
