using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainDumpApi_2.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, Cor) VALUES('Estudo', '#9697E8')");
            mb.Sql("INSERT INTO Categorias(Nome, Cor) VALUES('Trabalho', '#7987A1')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias");
        }
    }
}
