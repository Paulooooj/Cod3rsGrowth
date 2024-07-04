using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240703075800)]
    public class _20240703075800_migracao_da_tabela_empresa : Migration
    {
        public override void Up()
        {
            Create.Table("Empresa")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("RazaoSocial").AsString().NotNullable()
               .WithColumn("CNPJ").AsString().NotNullable()
               .WithColumn("Ramo").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Empresa");
        }
    }
}
