using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;

namespace Cod3rsGrowth.Infra
{
    public class DbCod3rsGrowth : LinqToDB.Data.DataConnection
    {
        public DbCod3rsGrowth(DataOptions<DbCod3rsGrowth> options) : base (options.Options) { }

        public ITable<Empresa> Empresas => this.GetTable<Empresa>();
        public ITable<Produto> Produtos => this.GetTable<Produto>();
    }
}
