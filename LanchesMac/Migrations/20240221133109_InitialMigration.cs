using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class InitialMigration : Migration
    {
        // Método para criação de tabelas
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criando tabela Categorias
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    // Criando seus atributos
                    CategoriaId = table.Column<int>(type: "int", nullable: false) 
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto incrementável
                    CategoriaNome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false) // Os atributos seguem as regras do Data Annotation
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId); // Definindo pk
                });

            // Criando tabela Lanches
            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    LancheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImagemThumbnailUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsLanchePreferido = table.Column<bool>(type: "bit", nullable: false),
                    EmEstoque = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.LancheId);
                    table.ForeignKey(
                        name: "FK_Lanches_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade); // Definindo FK
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanches_CategoriaId",
                table: "Lanches",
                column: "CategoriaId"); // Criando Index
        }

        // Método para exclusão de tabelas
        protected override void Down(MigrationBuilder migrationBuilder) 
        {
            migrationBuilder.DropTable(
                name: "Lanches");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
