using Cod3rsGrowth.Infra.Repositorio;
using LinqToDB;

namespace Cod3rsGrowth.Infra.DeletarEmpresa
{
    public class DeletarEmpresaTeste
    {
        public readonly DbCod3rsGrowth _db;

        public DeletarEmpresaTeste(DbCod3rsGrowth dbCod3Rs)
        {
            _db = dbCod3Rs;
        }
        public void DeletarEmpresaUsadaNosTestes()
        {
            const string empresaQueDeveSerDeletada = "Yooso";
            _db.Empresas
                .Delete(x => x.RazaoSocial == empresaQueDeveSerDeletada);
        }
    }
}
