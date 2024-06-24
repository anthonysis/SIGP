using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGP.Migrations
{
    /// <inheritdoc />
    public partial class telefoneEmPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar a coluna TelefoneId como nullable inicialmente
            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            // Criar um telefone fictício temporário
            migrationBuilder.Sql("INSERT INTO Telefone (CodigoDeArea, Numero, DataDeCriacao, DataDeAlteracao) VALUES (0, '0000-0000', GETDATE(), GETDATE())");

            // Atualizar registros existentes para garantir valores válidos, supondo que o Id do telefone fictício é o primeiro inserido
            migrationBuilder.Sql("UPDATE Pessoa SET TelefoneId = (SELECT TOP 1 Id FROM Telefone WHERE CodigoDeArea = 0 AND Numero = '0000-0000') WHERE TelefoneId IS NULL");

            // Criar o índice para a nova coluna
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TelefoneId",
                table: "Pessoa",
                column: "TelefoneId");

            // Adicionar a restrição de chave estrangeira
            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Telefone_TelefoneId",
                table: "Pessoa",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Remover o índice temporariamente para alterar a coluna
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_TelefoneId",
                table: "Pessoa");

            // Alterar a coluna para NOT NULL depois de atualizar os registros existentes
            migrationBuilder.AlterColumn<int>(
                name: "TelefoneId",
                table: "Pessoa",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            // Recriar o índice
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TelefoneId",
                table: "Pessoa",
                column: "TelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Telefone_TelefoneId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_TelefoneId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Pessoa");

            // Remover o telefone fictício temporário
            migrationBuilder.Sql("DELETE FROM Telefone WHERE CodigoDeArea = 0 AND Numero = '0000-0000'");
        }
    }
}  
