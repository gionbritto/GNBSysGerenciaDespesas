using Microsoft.EntityFrameworkCore.Migrations;

namespace GNBSys.GerenciaDespesas.Infra.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TTipoDespesa",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TTipoDespesa",
                type: "varchar",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
