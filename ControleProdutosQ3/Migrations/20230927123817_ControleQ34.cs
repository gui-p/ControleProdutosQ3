using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutosQ3.Migrations
{
    /// <inheritdoc />
    public partial class ControleQ34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Produto",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produto",
                newName: "id");
        }
    }
}
