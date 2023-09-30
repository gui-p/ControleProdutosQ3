using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutosQ3.Migrations
{
    /// <inheritdoc />
    public partial class ControleQ37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeDaFoto",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDaFoto",
                table: "Cliente");
        }
    }
}
