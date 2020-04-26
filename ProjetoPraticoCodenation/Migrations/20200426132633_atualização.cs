using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPraticoCodenation.Migrations
{
    public partial class atualização : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_log_erros_Usuario_UsuarioId",
                table: "log_erros");

            migrationBuilder.DropIndex(
                name: "IX_log_erros_UsuarioId",
                table: "log_erros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "log_erros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "log_erros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_log_erros_UsuarioId",
                table: "log_erros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_log_erros_Usuario_UsuarioId",
                table: "log_erros",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
