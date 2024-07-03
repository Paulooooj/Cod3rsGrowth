using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240703081400)]
    public class _20240703081400_migracao_da_tabela_Produto : Migration
    {
        public override void Up()
        {
            Create.Table("Produto")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("ValorDoProduto").AsDecimal(10, 2).NotNullable()
                .WithColumn("DataCadastro").AsDateTime().NotNullable()
                .WithColumn("TemDataValidade").AsBoolean().NotNullable()
                .WithColumn("DataValidade").AsDateTime().Nullable()
                .WithColumn("EmpresaId").AsInt32().ForeignKey("Empresa", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Produto");
        }
    }
}
