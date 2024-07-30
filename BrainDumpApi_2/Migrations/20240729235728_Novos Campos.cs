using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainDumpApi_2.Migrations
{
    /// <inheritdoc />
    public partial class NovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Notas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Notas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Categorias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Categorias");
        }
    }
}
