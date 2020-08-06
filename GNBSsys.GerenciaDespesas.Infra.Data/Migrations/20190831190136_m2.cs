using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GNBSys.GerenciaDespesas.Infra.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCarteira",
                columns: table => new
                {
                    CarteiraId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCarteira", x => x.CarteiraId);
                });

            migrationBuilder.CreateTable(
                name: "TTipoAtivo",
                columns: table => new
                {
                    TipoAtivoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTipoAtivo", x => x.TipoAtivoId);
                });

            migrationBuilder.CreateTable(
                name: "TTipoMovimentacaoCarteira",
                columns: table => new
                {
                    TipoMovimentacaoCarteiraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTipoMovimentacaoCarteira", x => x.TipoMovimentacaoCarteiraId);
                });

            migrationBuilder.CreateTable(
                name: "TAtivo",
                columns: table => new
                {
                    AtivoId = table.Column<Guid>(nullable: false),
                    TipoAtivoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAtivo", x => x.AtivoId);
                    table.ForeignKey(
                        name: "FK_TAtivo_TTipoAtivo_TipoAtivoId",
                        column: x => x.TipoAtivoId,
                        principalTable: "TTipoAtivo",
                        principalColumn: "TipoAtivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAtivoCarteira",
                columns: table => new
                {
                    AtivoId = table.Column<Guid>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAtivoCarteira", x => new { x.AtivoId, x.CarteiraId });
                    table.ForeignKey(
                        name: "FK_TAtivoCarteira_TAtivo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "TAtivo",
                        principalColumn: "AtivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAtivoCarteira_TCarteira_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "TCarteira",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMovimentacaoCarteira",
                columns: table => new
                {
                    MovimentacaoCarteiraId = table.Column<Guid>(nullable: false),
                    TipoMovimentacaoCarteiraId = table.Column<int>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false),
                    AtivoId = table.Column<Guid>(nullable: false),
                    MesId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataMovimentacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMovimentacaoCarteira", x => x.MovimentacaoCarteiraId);
                    table.ForeignKey(
                        name: "FK_TMovimentacaoCarteira_TAtivo_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "TAtivo",
                        principalColumn: "AtivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMovimentacaoCarteira_TCarteira_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "TCarteira",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMovimentacaoCarteira_TMes_MesId",
                        column: x => x.MesId,
                        principalTable: "TMes",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMovimentacaoCarteira_TTipoMovimentacaoCarteira_TipoMovimentacaoCarteiraId",
                        column: x => x.TipoMovimentacaoCarteiraId,
                        principalTable: "TTipoMovimentacaoCarteira",
                        principalColumn: "TipoMovimentacaoCarteiraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAtivo_TipoAtivoId",
                table: "TAtivo",
                column: "TipoAtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TAtivoCarteira_CarteiraId",
                table: "TAtivoCarteira",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_TMovimentacaoCarteira_AtivoId",
                table: "TMovimentacaoCarteira",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_TMovimentacaoCarteira_CarteiraId",
                table: "TMovimentacaoCarteira",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_TMovimentacaoCarteira_MesId",
                table: "TMovimentacaoCarteira",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_TMovimentacaoCarteira_TipoMovimentacaoCarteiraId",
                table: "TMovimentacaoCarteira",
                column: "TipoMovimentacaoCarteiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAtivoCarteira");

            migrationBuilder.DropTable(
                name: "TMovimentacaoCarteira");

            migrationBuilder.DropTable(
                name: "TAtivo");

            migrationBuilder.DropTable(
                name: "TCarteira");

            migrationBuilder.DropTable(
                name: "TTipoMovimentacaoCarteira");

            migrationBuilder.DropTable(
                name: "TTipoAtivo");
        }
    }
}
