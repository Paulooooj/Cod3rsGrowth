using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240627104900)]
    public class _20240627104900_atualizacao_da_tabela_produto : Migration
    {
        public override void Up()
        {
            Alter.Table("Produto")
                .AlterColumn("ValorDoProduto").AsDecimal(10, 2).NotNullable()
                .AlterColumn("DataValidade").AsDate().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }

    }
}
