using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migrations
{
    [Migration(20240625083500)]
    public class _20240625083500_migracao_da_tabela_empresa : Migration
    {
        public override void Up()
        {
            Alter.Table("Empresa")
                .AlterColumn("Ramo").AsInt32().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Empresa");
        }

    }
}
