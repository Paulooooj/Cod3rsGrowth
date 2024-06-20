
using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(2024062090000)]
    public class AdicionarTabelas : Migration
    {
        public override void Up()
        {
            Create.Table("Empresa")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("RazaoSocial").AsString().NotNullable()
                .WithColumn("CNPJ").AsString().NotNullable()
                .WithColumn("Ramo").AsString().NotNullable();

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
            Delete.Table("Empresa");
            Delete.Table("Produto");
        }

    }
}
