using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPraticoCodenation.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nm_usuario = table.Column<string>(maxLength: 100, nullable: false),
                    nm_login = table.Column<string>(maxLength: 30, nullable: false),
                    ds_senha = table.Column<string>(maxLength: 255, nullable: false),
                    cd_token = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "log_erros",
                columns: table => new
                {
                    id_log = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ds_titulo_log = table.Column<string>(maxLength: 250, nullable: false),
                    ds_log = table.Column<string>(maxLength: 8000, nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    cd_evento = table.Column<string>(maxLength: 50, nullable: false),
                    cd_nivel = table.Column<string>(maxLength: 50, nullable: false),
                    ds_ambiente = table.Column<string>(maxLength: 50, nullable: false),
                    nr_ip_origem = table.Column<string>(maxLength: 50, nullable: false),
                    fl_arquivado = table.Column<bool>(nullable: false),
                    nm_usuario_origem = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_erros", x => x.id_log);
                    table.ForeignKey(
                        name: "FK_log_erros_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_log_erros_UsuarioId",
                table: "log_erros",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log_erros");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
