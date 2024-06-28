using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240627105600)]
    public class _20240627105600_atualizacao_da_tabela_produto : Migration
    {
        public override void Up()
        {
            Alter.Table("Produto")
                .AlterColumn("DataCadastro").AsDate().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }
    }
}
