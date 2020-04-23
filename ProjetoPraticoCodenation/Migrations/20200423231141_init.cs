using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPraticoCodenation.Migrations
{
    public partial class init : Migration
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
                    id_usuario = table.Column<int>(nullable: false),
                    id_log = table.Column<int>(nullable: false),
                    ds_titulo_log = table.Column<string>(maxLength: 250, nullable: false),
                    ds_log = table.Column<string>(maxLength: 8000, nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_evento = table.Column<int>(nullable: false),
                    nivel = table.Column<string>(nullable: false),
                    ambiente = table.Column<string>(nullable: false),
                    ip = table.Column<string>(nullable: false),
                    arquivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_erros", x => x.id_usuario);
                    table.UniqueConstraint("AK_log_erros_id_log", x => x.id_log);
                    table.ForeignKey(
                        name: "FK_log_erros_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });
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
