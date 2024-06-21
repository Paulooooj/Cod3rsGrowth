using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240620132700)]
    public class _2024062090000_migracao_da_tabela_Produto : Migration
    {
        public override void Up()
        {
            Create.Table("Produto")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("ValorDoProduto").AsDecimal().NotNullable()
                .WithColumn("DataCadastro").AsDateTime().NotNullable()
                .WithColumn("TemDataValidade").AsBoolean().NotNullable()
                .WithColumn("DataValidade").AsDateTime()
                .WithColumn("EmpresaId").AsInt32().ForeignKey("Empresa", "Id");
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }
    }
}
