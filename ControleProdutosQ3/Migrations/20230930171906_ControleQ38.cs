using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutosQ3.Migrations
{
    /// <inheritdoc />
    public partial class ControleQ38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmado = table.Column<bool>(type: "bit", nullable: true),
                    TelefoneConfirmado = table.Column<bool>(type: "bit", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_Email",
                table: "Login",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
