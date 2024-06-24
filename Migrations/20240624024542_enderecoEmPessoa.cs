using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGP.Migrations
{
    /// <inheritdoc />
    public partial class enderecoEmPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar a coluna EnderecoId como nullable inicialmente
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            // Criar um endereço fictício temporário
            migrationBuilder.Sql("INSERT INTO Endereco (Cep, Logradouro, Numero, Complemento, Bairro, Estado, Cidade, Pais, DataDeCriacao, DataDeAlteracao) VALUES ('00000-000', 'Logradouro Fictício', 0, 'Complemento Fictício', 'Bairro Fictício', 'Estado Fictício', 'Cidade Fictícia', 'País Fictício', GETDATE(), GETDATE())");

            // Atualizar registros existentes para garantir valores válidos, supondo que o Id do endereço fictício é o primeiro inserido
            migrationBuilder.Sql("UPDATE Pessoa SET EnderecoId = (SELECT TOP 1 Id FROM Endereco WHERE Cep = '00000-000' AND Logradouro = 'Logradouro Fictício' AND Numero = 0 AND Complemento = 'Complemento Fictício' AND Bairro = 'Bairro Fictício' AND Estado = 'Estado Fictício' AND Cidade = 'Cidade Fictícia' AND Pais = 'País Fictício') WHERE EnderecoId IS NULL");

            // Criar o índice para a nova coluna
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            // Adicionar a restrição de chave estrangeira
            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pessoa");

            // Remover o endereço fictício temporário
            migrationBuilder.Sql("DELETE FROM Endereco WHERE Cep = '00000-000' AND Logradouro = 'Logradouro Fictício' AND Numero = 0 AND Complemento = 'Complemento Fictício' AND Bairro = 'Bairro Fictício' AND Estado = 'Estado Fictício' AND Cidade = 'Cidade Fictícia' AND Pais = 'País Fictício'");
        }
    }
}