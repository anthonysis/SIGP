using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGP.Migrations
{
    /// <inheritdoc />
    public partial class pessoaEmFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Funcionario");
        }
    }
}
